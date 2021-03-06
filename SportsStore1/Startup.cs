﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportsStore1.Models;

namespace SportsStore1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options=>
                options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
            services.AddTransient<IProductRepository, EFProductRepostiroy>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
          
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseSession();
                app.UseMvc(routes => {
                    routes.MapRoute(
                        name: null,
                        template: "{category}/Strona{productPage:int}",
                        defaults: new { controller = "Product", action = "List" }
                        );
                     routes.MapRoute(
                        name: null,
                        template:"Strona{productPage:int}",
                        defaults: new { controller="Product",
                        action="List",productPage=1}
                        );
                    routes.MapRoute(
                        name: null,
                        template: "{Category}",
                        defaults: new { controller = "Product", action = "List", productPage = 1 }
                        );
                    routes.MapRoute(
                        name: null,
                        template: "",
                        defaults: new { controller = "Product", action = "List", productPage = 1 }
                        );
                    routes.MapRoute(
                        name: null,
                        template: "{controller}/{action}/{id?}");

                    
                });
                SeedData.EnsurePopulated(app);

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
