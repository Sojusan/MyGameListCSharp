using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace MyGameList.Utilities
{
    public class EmailSender
    {
        string userEmailAddress;
        public int code { get; set; }
        public EmailSender(string userEmailAddress)
        {
            this.userEmailAddress = userEmailAddress;
            this.code = generateCode();
        }

        public void SendVerificationCode()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("mygamelistsender@gmail.com");
            mail.To.Add(userEmailAddress);
            mail.Subject = "MyGameList - Confirmation Code";
            mail.Body = "Hello !\nThis is your account confirmation code: " + code;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("MyGameListSender@gmail.com", "MyGameList123");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
        private int generateCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }
    }
}
