using Contracts;
using LoggerService;

namespace DebtNote_Backend.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()//WithOrigins("https://example.com")
            .AllowAnyMethod()       //WithMethods("POST", "GET") 
            .AllowAnyHeader());     //WithHeaders("accept", "contenttype")
            });
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => {});
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

    }
}
