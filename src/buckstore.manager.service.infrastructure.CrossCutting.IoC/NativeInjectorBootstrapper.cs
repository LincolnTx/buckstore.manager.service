using buckstore.manager.service.domain.Aggregates.ProductAggregate;
using buckstore.manager.service.domain.Exceptions;
using buckstore.manager.service.domain.SeedWork;
using buckstore.manager.service.infrastructure.Data.Context;
using buckstore.manager.service.infrastructure.Data.Repositories.ProductRepository;
using buckstore.manager.service.infrastructure.Data.UnitOfWork;
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
			services.AddDbContext<ApplicationDbContext>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IProductRepository, ProductRepository>();
		}

		public static void RegisterMediatR(IServiceCollection services)
		{
			// injection for Mediator
			services.AddScoped<INotificationHandler<ExceptionNotification>, ExceptionNotificationHandler>();
		}
	}
}