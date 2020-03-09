using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Extensions.Logging;
using Serilog.Hosting;
using TodoApp.Core;
using TodoApp.DAL;
using TodoApp.DAL.Repositories;
using TodoApp.Infra.Interfaces;
using ILogger = Serilog.ILogger;
using SerilogLoggerFactory = Serilog.Extensions.Logging.SerilogLoggerFactory;

namespace TodoApp.Api
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
            var config = new Config();
            Configuration.Bind(config);
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IDesignTimeDbContextFactory<ApplicationContext>>(x => new ApplicationContextFactory(config.DatabaseConnectionString, x.GetService<ILoggerFactory>()));
            services.AddTransient(x =>
                x.GetService<IDesignTimeDbContextFactory<ApplicationContext>>().CreateDbContext(new[] {""}));
            
            services.AddTransient<ITasksRepository, TasksRepository>();
            services.AddTransient<ITasksService, TasksService>();
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            });

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Todo app Api.",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();
            
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                x.RoutePrefix = "swagger";
            });
            
            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseCors();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}