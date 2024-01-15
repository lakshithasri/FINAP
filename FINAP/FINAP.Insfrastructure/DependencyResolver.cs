using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using FINAP.Insfrastructure.Repositories.CustomerRepo;
using FINAP.Domain.Interfaces.ICustomerRepository;

namespace FINAP.Insfrastructure
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepo>();
            return services;
        }
    }
}
