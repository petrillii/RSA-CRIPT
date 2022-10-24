using encrypt_rsa.BLL.Infra.Services.Interfaces;
using encrypt_rsa.BLL.Services;
using encrypt_rsa.Repository.Infra.Repositories.Interfaces;
using encrypt_rsa.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encrypt_rsa.IoC
{
    public static class DependencyInjectionHandler
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            #region Repository
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Business
            services.AddScoped<IRSAService, RSAService>();
            services.AddScoped<IUserService, UserService>();
            #endregion
            return services;
        }
    }
}
