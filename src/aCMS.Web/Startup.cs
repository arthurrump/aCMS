﻿//     Copyright 2016 Arthur Rump
//  
//     Licensed under the Apache License, Version 2.0 (the "License");
//     you may not use this file except in compliance with the License.
//     You may obtain a copy of the License at
//  
//         http://www.apache.org/licenses/LICENSE-2.0
//  
//     Unless required by applicable law or agreed to in writing, software
//     distributed under the License is distributed on an "AS IS" BASIS,
//     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//     See the License for the specific language governing permissions and
//     limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Hosting;
using Microsoft.Dnx.Runtime;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Entity;
using aCMS.Core.Models;
using aCMS.Core.Services;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNet.FileProviders;

namespace aCMS.Web
{
    public class Startup
    {
        IApplicationEnvironment _appEnv;

        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddEnvironmentVariables();
            if (env.IsDevelopment()) builder.AddUserSecrets();

            Configuration = builder.Build();

            _appEnv = appEnv;
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<CmsContext>(options => options.UseSqlServer(Configuration["SQLConnectionString"]));

            // Add services to connect to the database for each type of data in the database
            services.AddScoped<IDataService<Blog>, DatabaseDataService<Blog>>();
            services.AddScoped<IDataService<Post>, DatabaseDataService<Post>>();
            services.AddScoped<IDataService<Page>, DatabaseDataService<Page>>();
            services.AddScoped<IDataService<Author>, DatabaseAuthorService>();

            services.AddMvc()
                .AddRazorOptions(options =>
                    {
                        options.FileProvider = new PhysicalFileProvider($"{_appEnv.ApplicationBasePath}/Themes/CleanBlog");
                    });

            services.AddInstance(typeof(IConfiguration), Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();

                loggerFactory.AddConsole(LogLevel.Debug);
            }

            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Index}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "home",
                    template: "{action=Index}/",
                    defaults: new { controller = "Index" });
            });
        }
    }
}
