using Microsoft.Extensions.DependencyInjection;
using OpenPayApi.Services;
using OpenPayApi.Services.InstallmentPlans;

namespace OpenPayApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IInstallmentService, InstallmentService>();
            services.AddSingleton<IInstallmentPlan, LessThan100InstallmentPlan>();
            services.AddSingleton<IInstallmentPlan, LessThan1000InstallmentPlan>();
            services.AddSingleton<IInstallmentPlan, LessThan10000InstallmentPlan>();
            services.AddSingleton<IInstallmentPlan, LargerThan10000InstallmentPlan>();

            return services;
        }
    }
}