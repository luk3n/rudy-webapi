using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Rudy.WebAPI.Mappings;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System.Reflection;
using Rudy.Services;
using NetCore.AutoRegisterDi;
using Rudy.Persistence;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Rudy.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rudy API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigureServicesInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var assemblyToScan = Assembly.GetAssembly(typeof(ClientService));

            services.RegisterAssemblyPublicNonGenericClasses(assemblyToScan)
              .Where(c => c.Name.EndsWith("Service"))
              .AsPublicImplementedInterfaces();
        }

        public static void ConfigureEF(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StockContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("fysdb"), 
                builder => builder.UseRowNumberForPaging()));
        }
    }
}
