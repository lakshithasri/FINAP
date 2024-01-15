using Microsoft.Extensions.DependencyInjection;

namespace FINAP.Extensions
{
    public static class ServiceExtension
    {
        private static readonly string[] corsOrigins = new string[] { "http://localhost:4200" };

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(corsOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
