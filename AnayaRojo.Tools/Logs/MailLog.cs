using AnayaRojo.Tools.Logs.Enums;
using System;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnayaRojo.Tools.Extensions.Enums;
using AnayaRojo.Tools.Extensions.Object;
using AnayaRojo.Tools.Extensions.String;
using System.IO;
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
        public void Send(string pStrMessage)
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
        public void Send(LogTypeEnum pEnmType, string pStrMessage)
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
        public void Send(LogTypeEnum pEnmType, string pStrFormat, params object[] pArrObjArgs)
        {
            SendMail(pEnmType, string.Format(pStrFormat, pArrObjArgs));
        }

        private void SendMail(LogTypeEnum pEnmType, string pStrMessage)
        {
            if (Log.Configuration.MailLog.Active)
            {
                MailMessage lObjMailMessage = new MailMessage();

                try
                {
                    // From mail
                    lObjMailMessage.From = new MailAddress(Log.Configuration.MailLog.FromMail, Log.Configuration.MailLog.FromName);

                    // To mails
                    lObjMailMessage.To.Add(new MailAddress(Log.Configuration.MailLog.ToMail, Log.Configuration.MailLog.ToName));

                    // Views
                    string lStrDefaultView = this.GetTextFromResource("AnayaRojo.Tools.Logs.Resources.Templates.DefaultMailTemplate.html");
                    lStrDefaultView = lStrDefaultView.InjectSingleValue("Title", "");
                    lStrDefaultView = lStrDefaultView.InjectSingleValue("Type", "");
                    lStrDefaultView = lStrDefaultView.InjectSingleValue("Date", "");
                    lStrDefaultView = lStrDefaultView.InjectSingleValue("Time", "");


                    // Content
                    lObjMailMessage.Subject = string.Format("{0} on {1}", pEnmType.GetDescription(), GetAppName());
                    lObjMailMessage.Body = PopulateParameters
                    (
                        this.GetTextFromResource("AnayaRojo.Tools.Logs.Resources.Templates.DefaultMailTemplate.html"), 
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
                            this.GetTextFromResource("AnayaRojo.Tools.Logs.Resources.Templates.CustomMailTemplate.html"), 
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

        private string PopulateParameters(string pStrHtml, LogTypeEnum pEnmType, string pStrMessage)
        {
            pStrHtml = pStrHtml.InjectSingleValue("Title", pEnmType.GetDescription());
            pStrHtml = pStrHtml.InjectSingleValue("Type", pEnmType.GetDescription());
            pStrHtml = pStrHtml.InjectSingleValue("Date", DateTime.Now.ToString("dd de MMMM de yyyy"));
            pStrHtml = pStrHtml.InjectSingleValue("Time", DateTime.Now.ToString("hh:mm:ss tt"));
            pStrHtml = pStrHtml.InjectSingleValue("MessageTitle", "Mensaje");
            pStrHtml = pStrHtml.InjectSingleValue("Message", pStrMessage);
            pStrHtml = pStrHtml.InjectSingleValue("Author", GetAppName());
            return pStrHtml;
        }

        private Stream GetIconStream(LogTypeEnum pEnmType)
        {
            switch (pEnmType)
            {
                case LogTypeEnum.SUCCESS:
                    return this.GetStreamFromResource("AnayaRojo.Tools.Logs.Resources.Images.Success.jpg");
                case LogTypeEnum.INFO:
                    return this.GetStreamFromResource("AnayaRojo.Tools.Logs.Resources.Images.Information.jpg");
                case LogTypeEnum.PROCESS:
                    return this.GetStreamFromResource("AnayaRojo.Tools.Logs.Resources.Images.Process.jpg");
                case LogTypeEnum.TRACKING:
                    return this.GetStreamFromResource("AnayaRojo.Tools.Logs.Resources.Images.Tracking.jpg");
                case LogTypeEnum.WARNING:
                    return this.GetStreamFromResource("AnayaRojo.Tools.Logs.Resources.Images.Warning.jpg");
                case LogTypeEnum.ERROR:
                    return this.GetStreamFromResource("AnayaRojo.Tools.Logs.Resources.Images.Exception.jpg");
                case LogTypeEnum.EXCEPTION:
                    return this.GetStreamFromResource("AnayaRojo.Tools.Logs.Resources.Images.Exception.jpg");
                default:
                    return this.GetStreamFromResource("AnayaRojo.Tools.Logs.Resources.Images.Information.jpg");
            }
        }

        private static string GetAppName()
        {
            return System.AppDomain.CurrentDomain.FriendlyName;
        }
    }
}
