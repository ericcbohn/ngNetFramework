using log4net.Appender;
using System.Net.Mail;

namespace ngMayo.Logging.Appenders
{
    public class AuthenticatedSmtpAppender : SmtpAppender
    {
        public bool IsBodyHtml { get; set; }

        protected override void SendEmail(string messageBody)
        {
            // .NET 2.0 has a new API for SMTP email System.Net.Mail
            // This API supports credentials and multiple hosts correctly.
            // The old API is deprecated.

            // Create and configure the smtp client
            SmtpClient smtpClient = new SmtpClient();
            if (!string.IsNullOrEmpty(SmtpHost))
            {
                smtpClient.Host = SmtpHost;
            }
            smtpClient.Port = Port;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = EnableSsl;

            if (Authentication == SmtpAuthentication.Basic)
            {
                // Perform basic authentication
                smtpClient.Credentials = new System.Net.NetworkCredential(Username, Password);
            }
            else if (Authentication == SmtpAuthentication.Ntlm)
            {
                // Perform integrated authentication (NTLM)
                smtpClient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            }

            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.IsBodyHtml = IsBodyHtml;
                mailMessage.Body = messageBody;
                //mailMessage.BodyEncoding = BodyEncoding;
                mailMessage.From = new MailAddress(From);
                mailMessage.To.Add(To);
                if (!string.IsNullOrEmpty(Cc))
                {
                    mailMessage.CC.Add(Cc);
                }
                if (!string.IsNullOrEmpty(Bcc))
                {
                    mailMessage.Bcc.Add(Bcc);
                }
                if (!string.IsNullOrEmpty(ReplyTo))
                {
                    // .NET 4.0 warning CS0618: 'System.Net.Mail.MailMessage.ReplyTo' is obsolete:
                    // 'ReplyTo is obsoleted for this type.  Please use ReplyToList instead which can accept multiple addresses. http://go.microsoft.com/fwlink/?linkid=14202'

                    mailMessage.ReplyToList.Add(new MailAddress(ReplyTo));
                }
                mailMessage.Subject = Subject;
                //mailMessage.SubjectEncoding = m_subjectEncoding;
                mailMessage.Priority = Priority;

                // TODO: Consider using SendAsync to send the message without blocking. This would be a change in
                // behaviour compared to .NET 1.x. We would need a SendCompletedCallback to log errors.
                smtpClient.Send(mailMessage);
            }
        }
    }
}
