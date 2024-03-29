using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buckstore.manager.service.api.v1.Filters;
using buckstore.manager.service.application.CommandHandlers;
using buckstore.manager.service.infrastructure.CrossCutting.IoC.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace buckstore.manager.service.api.v1
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSwaggerSetup();
			services.AddAutoMapper();
			services.AddDependencyInjectionSetup(Configuration);
			services.AddMediatR(typeof(CommandHandler));
			services.AddScoped<GlobalExceptionFilterAttribute>();
			services.AddDatabaseSetup();
			services.AddKafka(Configuration);

			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

            app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
			app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
			app.UseSwaggerSetup();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}
