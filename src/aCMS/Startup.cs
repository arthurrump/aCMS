using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Hosting;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Logging;
using Microsoft.Data.Entity;
using aCMS.Models;
using aCMS.Services;

namespace aCMS
{
    public class Startup
    {
        IApplicationEnvironment _appEnv;

        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            _appEnv = appEnv;
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<CmsContext>(options => options.UseSqlite($"Data Source={_appEnv.ApplicationBasePath}/Data/data.db"));

            // Add services to connect to the database for each type of data in the database
            services.AddTransient<IDataService<Blog>, DatabaseDataService<Blog>>();
            services.AddTransient<IDataService<Post>, DatabaseDataService<Post>>();
            services.AddTransient<IDataService<Page>, DatabaseDataService<Page>>();

            services.AddMvc();

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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Index}/{action=Index}/{id?}");
            });
        }
    }
}
