using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR.LeaveManagement.Application
{
    // This is use to setup services at the start of the application  

    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }

    }
}
