using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class MailSender 
    {
        public MailAddress From { get; set; } 
        public MailAddress To { get; set; }

        public SmtpClient Smtp { get; set; } 

        public MailSender(MailAddress to)
        {
            Smtp = new SmtpClient("smtp.gmail.com", 587); 
            Smtp.EnableSsl = true;
            Smtp.Credentials = new NetworkCredential("giftshop.saless@gmail.com", "Gstore2021"); 
            From = new MailAddress("giftshop.saless@gmail.com", "GiftShop");
            To = to;
        }

        public MailSender()
        {
            Smtp = new SmtpClient("smtp.gmail.com", 587);
            Smtp.EnableSsl = true;
            Smtp.Credentials = new NetworkCredential("giftshop.saless@gmail.com", "Gstore2021");
            From = new MailAddress("giftshop.saless@gmail.com", "GiftShop");
        }

        public async Task SendEmailAsync(string subject, string message)
        {
            MailMessage mailMessage = new MailMessage(From, To);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            await Smtp.SendMailAsync(mailMessage);
        }

        public async Task SendEmailAsync(string subject, string message, string to)
        {
            MailAddress address = new MailAddress(to);
            MailMessage mailMessage = new MailMessage(From, address);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            await Smtp.SendMailAsync(mailMessage);
        }

    }
}
