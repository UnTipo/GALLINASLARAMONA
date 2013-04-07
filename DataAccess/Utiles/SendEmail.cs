using Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utiles
{
    public class SendEmail
    {

        public static void SendForgotPassword(string emailTO, string NewPassword, string url)
        {
            try
            {

                string body = url;
                MailMessage myHtmlMessage;

                SmtpClient mySmtpClient;

                myHtmlMessage = new MailMessage(Constants.EmailNoReply, emailTO, "COCHE AMIGOS: Recuperar tu contraseña", body);

                mySmtpClient = new SmtpClient(Constants.EmailSMTPNoReply);

                mySmtpClient.Credentials = new System.Net.NetworkCredential(Constants.EmailNoReply, Constants.EmailNoReplyPassword);

                mySmtpClient.EnableSsl = true;

                mySmtpClient.Port = int.Parse(Constants.EmailPort);

                mySmtpClient.Send(myHtmlMessage);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
