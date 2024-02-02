using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentList.Application.Interfaceses;
using StudentList.Infrastructure.Context;
using StudentList.Infrastructure.Interceptors;

namespace StudentList.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IStudentDbContext, StudentDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DbConnect"));
                options.UseLazyLoadingProxies();
            });

            services.AddScoped<IStudentDbContext, StudentDbContext>();

            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            return services;
        }
    }
}
