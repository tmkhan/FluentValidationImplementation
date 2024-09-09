using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
