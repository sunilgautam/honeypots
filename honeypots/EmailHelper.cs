using System.Net.Mail;
using System.Configuration;
using System;

namespace honeypots
{
    class EmailHelper
    {
        public static EmailSender Instance
        {
            get
            {
                return new EmailSender();
            }
        }
    }

    class EmailSender
    {
        public void Send(string subject, string message)
        {
            try
            {
                if (ConfigurationManager.AppSettings["honeypots.email.flag"] == "1")
                {
                    string sender = ConfigurationManager.AppSettings["honeypots.sender"];
                    string senderName = ConfigurationManager.AppSettings["honeypots.senderName"];
                    string receiver = ConfigurationManager.AppSettings["honeypots.adminEmail"];
                    string credentialUserName = ConfigurationManager.AppSettings["honeypots.emailUserName"];
                    string credentialPass = ConfigurationManager.AppSettings["honeypots.emailPassword"];
                    string host = ConfigurationManager.AppSettings["honeypots.emailHost"];
                    string isHtml = ConfigurationManager.AppSettings["honeypots.emailIsHtml"];
                    string isSSL = ConfigurationManager.AppSettings["honeypots.emailIsSSL"];
                    string port = ConfigurationManager.AppSettings["honeypots.emailPost"];

                    MailMessage mailMessage = new MailMessage(new MailAddress(sender, senderName), new MailAddress(receiver));
                    mailMessage.Subject = subject;
                    mailMessage.IsBodyHtml = (isHtml == "1") ? true : false;

                    mailMessage.Body = message;

                    System.Net.NetworkCredential networkCredentials = new System.Net.NetworkCredential(credentialUserName, credentialPass);

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.EnableSsl = (isSSL == "1") ? true : false;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = networkCredentials;
                    smtpClient.Host = host;
                    if (port != "-1")
                    {
                        smtpClient.Port = Convert.ToInt32(port);
                    }
                    smtpClient.Send(mailMessage);
                }
            }
            catch
            {

            }
        }
    }
}