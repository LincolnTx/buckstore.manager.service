using System;
using AutoMapper;
using buckstore.manager.service.application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace buckstore.manager.service.infrastructure.CrossCutting.IoC.Configurations
{
	public static class AutoMapperSetup
	{
		public static void AddAutoMapper(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			services.AddAutoMapper(typeof(MappingProfile));
		}
	}
}