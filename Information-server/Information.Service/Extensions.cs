using AutoMapper;
using Information.Repository;
using Information.Repository.Interfaces;
using Information.Service.Interfaces;
using Information.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Information.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();

            services.AddScoped<IinformationService, InformationService>();
            services.AddScoped<IChaildService, ChaildService>();
            

            //services.AddAutoMapper(typeof(Mapping));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
