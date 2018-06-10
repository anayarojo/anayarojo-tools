using AnayaRojo.Tools.Extensions.Enums;
using AnayaRojo.Tools.Extensions.Object;
using AnayaRojo.Tools.Extensions.String;
using AnayaRojo.Tools.Logs.Enums;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace AnayaRojo.Tools.Logs
{
    /// <summary>
    ///     Herramienta para enviar el log por correo electrónico.
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 03/06/2018
    /// </remarks>
    public class MailLog
    {
        /// <summary>
        ///     Mostrar log.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje.
        /// </param>
        public static void Send(string pStrMessage)
        {
            SendMail(LogTypeEnum.INFO, pStrMessage);
        }

        /// <summary>
        ///     Mostrar log.
        /// </summary>
        /// <param name="pEnmType">
        ///     Tipo del log.
        /// </param>
        /// <param name="pStrMessage">
        ///     Mensaje.
        /// </param>
        public static void Send(LogTypeEnum pEnmType, string pStrMessage)
        {
            SendMail(pEnmType, pStrMessage);
        }

        /// <summary>
        ///     Mostrar log.
        /// </summary>
        /// <param name="pEnmType">
        ///     Tipo del log.
        /// </param>
        /// <param name="pStrFormat">
        ///     Formato.
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parametros.
        /// </param>
        public static void Send(LogTypeEnum pEnmType, string pStrFormat, params object[] pArrObjArgs)
        {
            SendMail(pEnmType, string.Format(pStrFormat, pArrObjArgs));
        }

        private static void SendMail(LogTypeEnum pEnmType, string pStrMessage)
        {
            if (Log.Configuration.MailLog.Active)
            {
                MailMessage lObjMailMessage = new MailMessage();

                try
                {
                    // From mail
                    lObjMailMessage.From = new MailAddress(Log.Configuration.MailLog.FromMail, Log.Configuration.MailLog.FromName);

                    string[] lArrToMails = Log.Configuration.MailLog.ToMail.Split(';');
                    string[] lArrToNames = Log.Configuration.MailLog.ToName.Split(';');

                    for (int i = 0; i < lArrToMails.Length; i++)
                    {
                        // To mails
                        lObjMailMessage.To.Add(new MailAddress(lArrToMails[i], lArrToNames[i]));
                    }
                    
                    // Content
                    lObjMailMessage.Subject = string.Format("{0} en {1}", pEnmType.GetDescription(), GetAppName());
                    lObjMailMessage.Body = PopulateParameters
                    (
                        ObjectExtension.GetTextFromResource<MailLog>
                        (
                            "AnayaRojo.Tools.Logs.Resources.Templates.DefaultMailTemplate.html"
                        ),
                        pEnmType, 
                        pStrMessage
                    );
                    lObjMailMessage.IsBodyHtml = true;
                    lObjMailMessage.Priority = MailPriority.Normal;

                    // Get mail icon
                    LinkedResource lObjLinkedImage = new LinkedResource(GetIconStream(pEnmType));
                    lObjLinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
                    lObjLinkedImage.ContentId = "Icon";

                    // Create view
                    AlternateView lObjHtmlView = AlternateView.CreateAlternateViewFromString
                    (
                        PopulateParameters
                        (
                            ObjectExtension.GetTextFromResource<MailLog>
                            (
                                "AnayaRojo.Tools.Logs.Resources.Templates.CustomMailTemplate.html"
                            ),
                            pEnmType, 
                            pStrMessage
                        ), 
                        null, 
                        "text/html"
                    );

                    // Add view
                    lObjHtmlView.LinkedResources.Add(lObjLinkedImage);
                    lObjMailMessage.AlternateViews.Add(lObjHtmlView);

                    // Mail account
                    SmtpClient lObjClient = new SmtpClient();
                    lObjClient.UseDefaultCredentials = false;
                    lObjClient.Credentials = new NetworkCredential(Log.Configuration.MailLog.User, Log.Configuration.MailLog.Password);
                    lObjClient.Host = Log.Configuration.MailLog.Server;
                    lObjClient.Port = Log.Configuration.MailLog.Port;
                    lObjClient.EnableSsl = Log.Configuration.MailLog.EnableSsl;

                    // Send
                    lObjClient.Send(lObjMailMessage);
                }
                catch (Exception lObjException)
                {
                    Log.Write(lObjException);
                }
                finally
                {
                    lObjMailMessage.Dispose();
                }
            }
        }

        private static string PopulateParameters(string pStrHtml, LogTypeEnum pEnmType, string pStrMessage)
        {
            pStrHtml = pStrHtml.InjectSingleValue("Title", pEnmType.GetDescription());
            pStrHtml = pStrHtml.InjectSingleValue("Type", pEnmType.GetDescription());
            pStrHtml = pStrHtml.InjectSingleValue("Date", DateTime.Now.ToString("dd' de 'MMMM' de 'yyyy"));
            pStrHtml = pStrHtml.InjectSingleValue("Time", DateTime.Now.ToString("hh:mm:ss tt"));
            pStrHtml = pStrHtml.InjectSingleValue("MessageTitle", "Mensaje");
            pStrHtml = pStrHtml.InjectSingleValue("Message", pStrMessage);
            pStrHtml = pStrHtml.InjectSingleValue("Author", Log.Configuration.MailLog.AuthorName);
            return pStrHtml;
        }

        private static Stream GetIconStream(LogTypeEnum pEnmType)
        {
            string lStrAssemblyPath = "";

            switch (pEnmType)
            {
                case LogTypeEnum.SUCCESS:
                    lStrAssemblyPath = "AnayaRojo.Tools.Logs.Resources.Images.Success.jpg";
                    break;
                case LogTypeEnum.INFO:
                    lStrAssemblyPath = "AnayaRojo.Tools.Logs.Resources.Images.Information.jpg";
                    break;
                case LogTypeEnum.PROCESS:
                    lStrAssemblyPath = "AnayaRojo.Tools.Logs.Resources.Images.Process.jpg";
                    break;
                case LogTypeEnum.TRACKING:
                    lStrAssemblyPath = "AnayaRojo.Tools.Logs.Resources.Images.Tracking.jpg";
                    break;
                case LogTypeEnum.WARNING:
                    lStrAssemblyPath = "AnayaRojo.Tools.Logs.Resources.Images.Warning.jpg";
                    break;
                case LogTypeEnum.ERROR:
                    lStrAssemblyPath = "AnayaRojo.Tools.Logs.Resources.Images.Exception.jpg";
                    break;
                case LogTypeEnum.EXCEPTION:
                    lStrAssemblyPath = "AnayaRojo.Tools.Logs.Resources.Images.Exception.jpg";
                    break;
                default:
                    lStrAssemblyPath = "AnayaRojo.Tools.Logs.Resources.Images.Information.jpg";
                    break;
            }

            return ObjectExtension.GetStreamFromResource<MailLog>(lStrAssemblyPath);
        }

        private static string GetAppName()
        {
            return Log.Configuration.MailLog.ApplicationName;
        }
    }
}
