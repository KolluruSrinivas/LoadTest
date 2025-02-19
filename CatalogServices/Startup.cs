using CatalogService.databases;
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
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService
{
    public class Startup

    {
        public Startup(IConfiguration configuration)
        {
            Confguration = configuration;

        }
        public IConfiguration Confguration { get; }

        public void ConfigurationServices(IServiceCollection services)
        {
            services.AddControllers();
            string strConn = Environment.GetEnvironmentVariable("DefaultConnection");
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(strConn);
            });
            services.AddSwaggerGen(c =>
            {
               
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CatlogService", Version = "v1" });

            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CatalogService v1"));
            }
            app.UseRouting();
          //  app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

