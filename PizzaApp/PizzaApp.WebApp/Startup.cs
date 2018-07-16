using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaApp.Context;
using PizzaApp.Library;

namespace PizzaApp.WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<PizzaAppDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppDB")));

            services.AddScoped<PizzaRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "User",
                    template: "User/{action=Index}/{id?}",
                    defaults: new { controller = "User" });

                routes.MapRoute(
                    name: "Location",
                    template: "Location/{action=Index}/{id?}",
                    defaults: new { controller = "Location" });

                routes.MapRoute(
                    name: "Inventory",
                    template: "Inventory/{action=Index}/{id?}",
                    defaults: new { controller = "Inventory" });

                routes.MapRoute(
                    name: "Order",
                    template: "Order/{action=Index}/{id?}",
                    defaults: new { controller = "Order" });

                routes.MapRoute(
                    name: "Pizza",
                    template: "Pizza/{action=Index}/{id?}",
                    defaults: new { controller = "Pizza" });

                routes.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
