using LanguageExchange.Core.RepositoriesInterfaces;
using LanguageExchange.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageExchange.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection InfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAdditionalUserInformationRepository, AdditionalUserInformationRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<ISubscriptionPlanRepository, SubscriptionPlanRepository>(); 
            return services;
        }
    }
}
