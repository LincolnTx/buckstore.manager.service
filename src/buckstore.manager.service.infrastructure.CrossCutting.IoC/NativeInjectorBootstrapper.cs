using buckstore.manager.service.domain.Aggregates.ProductAggregate;
using buckstore.manager.service.domain.Exceptions;
using buckstore.manager.service.infrastructure.Data.Repositories.ProductRepository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace buckstore.manager.service.infrastructure.CrossCutting.IoC
{
	public class NativeInjectorBootstrapper
	{
		public static void RegisterServices(IServiceCollection services)
		{
			RegisterData(services);
			RegisterMediatR(services);
		}

		public static void RegisterData(IServiceCollection services)
		{
			services.AddScoped<IProductRepository, ProductRepository>();
		}

		public static void RegisterMediatR(IServiceCollection services)
		{
			// injection for Mediator
			services.AddScoped<INotificationHandler<ExceptionNotification>, ExceptionNotificationHandler>();
		}
	}
}