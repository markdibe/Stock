using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StockBO;
using StockDAO;
using StockDAO.Context;

namespace StockApi
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
            services.AddDbContext<StockContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("StockConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(StockContext).Assembly.FullName));
            });
            services.AddScoped<FacadeBO>();
            services.AddScoped<FacadeDAO>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDataProtection();

            services.Configure<AllowedOrigins>(Configuration.GetSection("AllowedOrigins"));
            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptionsMonitor<AllowedOrigins> options)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(cors =>
            {
                cors.WithOrigins(
                    options.CurrentValue.AngularOrigin,
                    options.CurrentValue.FacebookOrigin)
                .AllowAnyHeader().AllowAnyMethod();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
