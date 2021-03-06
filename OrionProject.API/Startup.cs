using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OrionProject.Core.Interfaces;
using OrionProject.Core.Services;
using OrionProject.Infrastructure.Context;
using OrionProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionProject.API
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

            services.AddControllers()
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrionProject.API", Version = "v1" });
            });

            services.AddDbContext<OrionProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OrionProject")));

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrionProject.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(options => options.WithOrigins("*").WithMethods("*").WithHeaders("*"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
