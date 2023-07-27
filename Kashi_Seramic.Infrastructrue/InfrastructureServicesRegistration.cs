

using Pr_Signal_ir.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Kashi_Seramic.Application.Models;
using Kashi_Seramic.Application.Contracts.Infrastructure;

namespace Pr_Signal_ir.Application
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, GmailSender>();

            return services;
        }
    }
}
