using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortfolioPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioPro.BL;

namespace PortfolioPro
{
    public class Startup
    {
        IConfiguration config;
        public Startup(IConfiguration Ashraf)
        {
            config = Ashraf;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<PortfolioProContext>
               (options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IIslider, CLSslider>();
            services.AddScoped<IIabout, CLSabout>();
            services.AddScoped<IIservice, CLSservice>();
            services.AddScoped<IIfooter, CLSfooter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                app.UseEndpoints(endpoints =>
                {

                    endpoints.MapControllerRoute(
                       name: "areas",
                       pattern: "{area:exists}/{Controller=Home}/{action=Index}/{id?}");

                    endpoints.MapControllerRoute(
                        name: "default", pattern: "{Controller=Home}/{action=Index}/{id?}");
                });
            });
        }
    }
}
