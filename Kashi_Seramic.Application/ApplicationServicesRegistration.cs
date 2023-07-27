using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Kashi_Seramic.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());


            return services;
        }
    }
}
