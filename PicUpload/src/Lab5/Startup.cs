﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=localhost;Database=Lab5;Trusted_Connection=True;MultipleActiveResultSets=true";

            // if that fails try: var connection =

            // @"Server=localhost\SQLEXPRESS;Database=Lab5;Trusted_Connection=True;MultipleActiveResultSets=true";

            services.AddDbContext<PhotoDataContext>(options => options.UseSqlServer(connection));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())

            {

                app.UseDeveloperExceptionPage();

            }

            app.UseStaticFiles();

            app.UseMvc(routes =>

            {

                routes.MapRoute(

                name: "default",

                template: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}