using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceExtension
    {
        public static void AddPersistence(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(
                configuration.GetConnectionString("DefaultConnectionString")
                ));
            service.AddScoped<IApplicationDbContext,ApplicationDbContext>();
        }
    }
}
