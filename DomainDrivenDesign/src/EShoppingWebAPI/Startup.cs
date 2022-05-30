using AutoMapper;
using EShopping.Core.Domain;
using EShopping.Core.Persistence;
using EShoppingWebAPI.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EShoppingWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Filter
            services.AddControllers(options => options.Filters.Add(new AopExceptionHandlerFilter()));

            // FluentValidation
            services
               .AddMvcCore()
               .AddApiExplorer()
               .AddFluentValidation(s =>
               {
                   s.RegisterValidatorsFromAssemblyContaining<Startup>();
                   s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                   s.AutomaticValidationEnabled = true;
                   s.ImplicitlyValidateChildProperties = true;
               });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "EShoppingWebAPI", Version = "v1" });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "EShopping WebAPI",
                    Description = "ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "EShopping Web API",
                        Email = string.Empty,
                    },
                    License = new OpenApiLicense
                    {
                        Name = "DucVV",
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            // Register the Swagger services
            services.AddSwaggerDocument();

            services.AddDbContext<EShoppingDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // AutoMapper
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EShoppingWebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EShoppingWebAPI V1");
                c.RoutePrefix = string.Empty;
            });

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();

            app.UseSwaggerUi3();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
