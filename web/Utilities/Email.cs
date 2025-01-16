using System;
using System.Net.Mail;

namespace web.Utilities
{
    public static class Email
    {
        public static void Send(string sender, string subject, string body, bool isHtml = false)
        {
            var emailMsg = new MailMessage(sender.Trim(), "cheflaura@aknightsfeast.com", subject, body.Trim());

            emailMsg.IsBodyHtml = isHtml;

            new SmtpClient().Send(emailMsg);
        }
    }
}