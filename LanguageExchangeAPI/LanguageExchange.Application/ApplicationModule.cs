using LanguageExchange.Application.Services.AdditionalUserInformationServices;
using LanguageExchange.Application.Services.Language;
using LanguageExchange.Application.Services.LanguageServices;
using LanguageExchange.Application.Services.SubscriptionPlanServices;
using LanguageExchange.Application.Services.SubscriptionServices;
using LanguageExchange.Application.Services.UserAddressServices;
using LanguageExchange.Application.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageExchange.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection ApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAddressService, UserAddressService>();
            services.AddScoped<ISubscriptionPlanService, SubscriptionPlanService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IAdditionalUserInformationService, AdditionalUserInformationService>();

            return services;
        }
    }
}
