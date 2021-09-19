using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using buckstore.manager.service.application.Adapters.MessageBroker;
using buckstore.manager.service.application.IntegrationEvents;
using buckstore.manager.service.bus.MessageBroker.Kafka.Producers;
using buckstore.manager.service.domain.Aggregates.ProductAggregate;
using buckstore.manager.service.domain.Aggregates.SalesAggregate;
using buckstore.manager.service.domain.Exceptions;
using buckstore.manager.service.domain.SeedWork;
using buckstore.manager.service.environment.Configuration;
using buckstore.manager.service.infrastructure.Data.Context;
using buckstore.manager.service.infrastructure.Data.Repositories.ProductRepository;
using buckstore.manager.service.infrastructure.Data.Repositories.SaleRepository;
using buckstore.manager.service.infrastructure.Data.UnitOfWork;

namespace buckstore.manager.service.infrastructure.CrossCutting.IoC
{
	public class NativeInjectorBootstrapper
	{
		public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
		{
			RegisterData(services);
			RegisterMediatR(services);
			RegisterEnvironment(services, configuration);
			RegisterProducers(services);
		}

		public static void RegisterData(IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
		}

		public static void RegisterMediatR(IServiceCollection services)
		{
			services.AddScoped<INotificationHandler<ExceptionNotification>, ExceptionNotificationHandler>();
		}

		public static void RegisterEnvironment(IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(configuration.GetSection("JwtSettings").Get<JwtSettings>());
		}

		public static void RegisterProducers(IServiceCollection services)
		{
			services.AddScoped<IMessageProducer<ProductCreatedIntegrationEvent>, KafkaProducer<ProductCreatedIntegrationEvent>>();
			services.AddScoped<IMessageProducer<ProductUpdatedIntegrationEvent>, KafkaProducer<ProductUpdatedIntegrationEvent>>();
			services.AddScoped<IMessageProducer<ProductDeletedIntegrationEvent>, KafkaProducer<ProductDeletedIntegrationEvent>>();
		}
	}
}
