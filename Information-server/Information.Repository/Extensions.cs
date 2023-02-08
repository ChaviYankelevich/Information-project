using Information.Repository.Interfaces;
using Information.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Information.Repository
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IinformationRepository, InformationRepository>();
            services.AddScoped<IChaildRepository, ChaildRepository>();

            return services;
        }
    }
}
