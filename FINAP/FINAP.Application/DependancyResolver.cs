using FINAP.Application.Interfaces.ICustomerService;
using FINAP.Application.Services.CustomerService;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FINAP.Application
{
    public static class DependancyResolver
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<ICustomerService, CustomerService>();
            return services;
        }
    }
}