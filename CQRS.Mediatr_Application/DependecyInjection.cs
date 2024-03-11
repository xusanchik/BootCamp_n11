using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Mediatr_Application
{
    public static class DependecyInjection
    {
            public static IServiceCollection AddApplcationService(
                this IServiceCollection services)
            {
                services.AddMediatR(Assembly.GetExecutingAssembly());


                return services;
            }
    }
}
