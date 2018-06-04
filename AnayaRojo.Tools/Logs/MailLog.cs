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
            MailMessage lObjMailMessage = new MailMessage();

            // From mail
            lObjMailMessage.From = new MailAddress(Log.Configuration.MailLog.FromMail, Log.Configuration.MailLog.FromName);

            // To mails
            lObjMailMessage.To.Add(new MailAddress(Log.Configuration.MailLog.ToMail, Log.Configuration.MailLog.ToName));

            // Content
            lObjMailMessage.Subject = string.Format("{0} on {1}", pEnmType.GetDescription(), GetAppName());
            lObjMailMessage.Body = this.GetTextFromResource("AnayaRojo.Tools.Logs.Resources.Templates.DefaultMailTemplate.html");
            lObjMailMessage.IsBodyHtml = true;
            lObjMailMessage.Priority = MailPriority.Normal;

            //Cuenta
            SmtpClient lObjClient = new SmtpClient();
            lObjClient.UseDefaultCredentials = false;
            lObjClient.Credentials = new NetworkCredential(Log.Configuration.MailLog.User, Log.Configuration.MailLog.Password);
            lObjClient.Host = Log.Configuration.MailLog.Server;
            lObjClient.Port = Log.Configuration.MailLog.Port;

            LinkedResource LinkedImage = new LinkedResource(@"J:\My Documents\Advika1.jpg");

            //_client.EnableSsl = true;

            try
            {
                lObjClient.Send(lObjMailMessage);
                MessageBox.Show("Mensaje enviado...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            lObjMailMessage.Dispose();





            string lStrEventLogName = "";
            if (Log.Configuration.MailLog.Active)
            {
                try
                {
                    System.Diagnostics.EventLog lObjEventLog = new System.Diagnostics.EventLog();
                    lStrEventLogName = !string.IsNullOrEmpty(Log.Configuration.EventLog.Name) ?
                                                             Log.Configuration.EventLog.Name :
                                                             Process.GetCurrentProcess().ProcessName;

                    if (!System.Diagnostics.EventLog.SourceExists(lStrEventLogName))
                    {
                        System.Diagnostics.EventLog.CreateEventSource(lStrEventLogName, "Application");
                    }

                    lObjEventLog.Source = lStrEventLogName;
                    lObjEventLog.WriteEntry(pStrMessage, GetEntryType(pEnmType), GetEntryId(pEnmType));
                    lObjEventLog.Close();
                }
                catch (Exception lObjException)
                {
                    Log.Write(lObjException);
                }
            }
        }

        private static string GetAppName()
        {
            return System.AppDomain.CurrentDomain.FriendlyName;
        }
    }
}
