
using Pr_Signal_ir.Identity.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Kashi_Seramic.Identity.Models;
using Kashi_Seramic.Identity.Models.Security.PhoneTotp.Providers;
using Kashi_Seramic.Identity.Services;
using Pr_Signal_ir.Identity;
using Kashi_Seramic.Application.Models.Identity;
using Kashi_Seramic.Application.Contracts.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Kashi_Seramic.Identity.Models.PersianIdentityErrorDescriber;

namespace Kashi_Seramic.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MyIdentityConnectionString"),
                b => b.MigrationsAssembly(typeof(AppIdentityDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>(op =>
            {
                op.Password.RequireLowercase = false;
                op.Password.RequireUppercase = false;
                op.Password.RequireDigit = false;
                op.Password.RequireNonAlphanumeric = false;
                op.Password.RequiredLength = 6;
                

            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders()
                 .AddErrorDescriber<PersianIdentityErrorDescriber>();
            ;

            // services.AddTransient<IdentityRole, AuthService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddTransient<IPhoneTotpProvider, PhoneTotpProvider>();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(o =>
            //    {
            //        o.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ClockSkew = TimeSpan.Zero,
            //            ValidIssuer = configuration["JwtSettings:Issuer"],
            //            ValidAudience = configuration["JwtSettings:Audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            //        };
            //    });

            return services;
        }
    }
}
