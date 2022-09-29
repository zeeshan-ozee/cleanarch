using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.App.Common.Interfaces.Authentication;
using BuberDinner.App.Common.Interfaces.Services;
using BuberDinner.App.Services.Authentication;
using BuberDinner.Infra.Authentication;
using BuberDinner.Infra.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BuberDinner.Infra.Persistance;
using BuberDinner.App.Common.Interfaces.Persistance;

namespace BuberDinner.Infra
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplicationInfrasctructure(this IServiceCollection services,
         IConfiguration config
       )
        {

            services.Configure<JwtSettings>(config.GetSection(JwtSettings.Section_Name));


            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();


            return services;
        }
    }
}