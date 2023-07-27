
using Microsoft.Extensions.Options;

using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Runtime;
using System.Threading.Tasks;
using Kashi_Seramic.Application.Contracts.Infrastructure;
using Kashi_Seramic.Application.Models;

namespace Pr_Signal_ir.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _emailSettings { get; }
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}
