using Microsoft.Extensions.DependencyInjection.Extensions;
using MS_Financeiro.Kafka;
using MS_Financeiro.Repository;
using MS_Financeiro.Repository.Interface;
using MS_Financeiro.Services;
using MS_Financeiro.Services.Interface;

namespace MS_Financeiro.Ioc
{
    public static class RegisterIoc
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ICashFlowService, CashFlowService>();
            services.AddTransient<IHostedService, KafkaConsumerHandler>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICashFlowRepository, CashFlowRepository>();

            return services;
        }
    }
}
