using System;
using buckstore.manager.service.infrastructure.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace buckstore.manager.service.infrastructure.CrossCutting.IoC.Configurations
{
	public static class DatabaseSetup
	{
		public static void AddDatabaseSetup(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
		}
	}
}