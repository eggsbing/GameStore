using GameStore.Core.Services;
using GameStore.Core.Utilities.Security;
using GameStore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.IoC
{
    public static class Container
    {
        public static IServiceCollection AddIoCService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameStoreContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("GameStoreConnection"));
            });
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IGameGroupService, GameGroupService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IOrderService, OrderService>();

            return services;
        }
    }
}
