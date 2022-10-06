using Confluent.Kafka;
using MS_Financeiro.Dto;
using MS_Financeiro.Services.Interface;
using System.Text.Json;

namespace MS_Financeiro.Kafka
{
    public class KafkaConsumerHandler : IHostedService
    {
        private readonly string topic = "queue_cashFlow";
        private ICashFlowService _cashFlowService;

        public KafkaConsumerHandler(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            _cashFlowService = scope.ServiceProvider.GetRequiredService<ICashFlowService>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var conf = new ConsumerConfig
            {
                GroupId = "consumer_CashFlow",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var builder = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                builder.Subscribe(topic);
                try
                {
                    while (true)
                    {
                        var consumer = builder.Consume();
                        var obj = consumer.Message;
                        _cashFlowService.Add(JsonSerializer.Deserialize<CashFlowDto>(consumer.Message.Value));
                    }
                }
                catch (Exception)
                {
                    builder.Close();
                }
            }
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}