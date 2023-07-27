
using Microsoft.Extensions.Options;

using Pr_Signal_ir.Application.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;

using System.Text;
using System.Threading.Tasks;
using Kashi_Seramic.Application.Contracts.Infrastructure;
using Kashi_Seramic.Application.Models;
using Kashi_Seramic.Persistences;
using System.Linq;

namespace Pr_Signal_ir.Infrastructure.Mail
{
    public class GmailSender : IEmailSender
    {
        private readonly AppDbContext _context;
        private EmailSettings _emailSettings { get; }
        public GmailSender(IOptions<EmailSettings> emailSettings, AppDbContext context)
        {
            _context= context;
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var setting = _context.SiteSetting.FirstOrDefault();
            var fromAddress = new MailAddress(setting.Gmail, setting.Title);
            var toAddress = new MailAddress(email.To, "To Name");
            string fromPassword = (setting.GmailPassword);
            string subject = email.Subject;
            string body = email.Body;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
 
            return true;

        }
    }
}
