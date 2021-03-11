using buckstore.manager.service.domain.Aggregates.ProductAggregate;
using buckstore.manager.service.domain.Exceptions;
using buckstore.manager.service.domain.SeedWork;
using buckstore.manager.service.environment.Configuration;
using buckstore.manager.service.infrastructure.Data.Context;
using buckstore.manager.service.infrastructure.Data.Repositories.ProductRepository;
using buckstore.manager.service.infrastructure.Data.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace buckstore.manager.service.infrastructure.CrossCutting.IoC
{
	public class NativeInjectorBootstrapper
	{
		public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
		{
			RegisterData(services);
			RegisterMediatR(services);
			RegisterEnvironment(services, configuration);
		}

		public static void RegisterData(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IProductRepository, ProductRepository>();
		}

		public static void RegisterMediatR(IServiceCollection services)
		{
			services.AddScoped<INotificationHandler<ExceptionNotification>, ExceptionNotificationHandler>();
		}

		public static void RegisterEnvironment(IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(configuration.GetSection("JwtSettings").Get<JwtSettings>());
		}
	}
}