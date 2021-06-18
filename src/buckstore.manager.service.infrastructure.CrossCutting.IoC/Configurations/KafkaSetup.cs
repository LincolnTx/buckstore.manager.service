using System;
using buckstore.manager.service.application.IntegrationEvents;
using buckstore.manager.service.bus.MessageBroker.Kafka.Consumer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using buckstore.manager.service.environment.Configuration;
using MassTransit;
using MassTransit.Registration;

namespace buckstore.manager.service.infrastructure.CrossCutting.IoC.Configurations
{
    public static class KafkaSetup
    {
        private static KafkaConfiguration _kafkaConfiguration;
        public static void AddKafka(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            _kafkaConfiguration = configuration.GetSection("KafkaConfiguration").Get<KafkaConfiguration>();

            services.AddMassTransit(bus =>
            {
                bus.UsingInMemory((ctx, cfg) => cfg.ConfigureEndpoints(ctx));
                
                bus.AddRider(rider =>
                {
                    rider.AddConsumers();
                    rider.AddProducers();
                    
                    rider.UsingKafka((ctx, k) =>
                    {
                        k.Host(_kafkaConfiguration.ConnectionString);
                        
                        k.TopicEndpoint<OrderReceivedIntegrationEvent>(_kafkaConfiguration.OrdersToManager, _kafkaConfiguration.Group,
                        e =>
                        {
                            e.ConfigureConsumer<OrderReceivedConsumer>(ctx);
                            e.CreateIfMissing(options =>
                            {
                                options.NumPartitions = 3;
                                options.ReplicationFactor = 1;
                            });
                        });
                    });
                });
            });
            
            services.AddMassTransitHostedService();
        }

        static void AddConsumers(this IRegistrationConfigurator rider)
        {
            rider.AddConsumer<OrderReceivedConsumer>();
        }

        static void AddProducers(this IRiderRegistrationConfigurator rider)
        {
            
        }
    }
}