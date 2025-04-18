using System.Net;
using System.Net.Mail;

namespace Demo.Presention.Utilities
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var Client = new SmtpClient("smtp.gmail.com");
            Client.Port = 587;
            Client.Credentials = new NetworkCredential()
            {
                UserName = "mohammedosama1a2@gmail.com",
                Password = "xrvfortrmrwxbsui"
            };
            Client.EnableSsl = true;
            Client.Send("mohammedosama1a2@gmail.com",email.To, email.Subject, email.Body);
        }
    }
}
