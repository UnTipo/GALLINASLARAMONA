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

        public static void SendForgotPassword(string emailTO, string NewPassword)
        {
            try
            {

                string body = "New Password" + NewPassword;
                MailMessage myHtmlMessage;

                SmtpClient mySmtpClient;

                myHtmlMessage = new MailMessage("EmailFrom", "EmailTo", "Subject " + DateTime.Now.ToString(), body);

                mySmtpClient = new SmtpClient("smtp.gmail.com");

                mySmtpClient.Credentials = new System.Net.NetworkCredential("meramoroscon@gmail.com", "caudete2012a");

                mySmtpClient.EnableSsl = true;

                mySmtpClient.Port = 587;

                mySmtpClient.Send(myHtmlMessage);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
