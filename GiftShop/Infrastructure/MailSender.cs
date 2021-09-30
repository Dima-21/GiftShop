using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Infrastructure
{
    public class MailSender : IEmailSender
    {
        public BLL.Infrastructure.MailSender mailSender { get; set; }
        public MailSender()
        {
            mailSender = new BLL.Infrastructure.MailSender(); 
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return mailSender.SendEmailAsync(subject, htmlMessage, email);
        }
    }
}
