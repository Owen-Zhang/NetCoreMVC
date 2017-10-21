using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore2MVC.Models;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using NetCore2MVC.Common;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using KJT.WebFrameWork.Common;

namespace NetCore2MVC
{
    public class Startup
    {
        /*
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }*/

        public Startup(IHostingEnvironment environment)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("Configuration/Test.json", false, reloadOnChange: true)
                .AddXmlFile("Configuration/Route.config", false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            ConfigurationManager.ConfigurationT = Configuration;

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var appSettings = Configuration.GetSection("qwert");
            services.Configure<AppSettingDetail>(appSettings);

            var testJsonSetting = Configuration.GetSection("TestJson");
            services.Configure<TestJsonModel>(testJsonSetting);

            services.AddMvc();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DefaultModule>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();

            //在这里可以将container保存下来，可以直接调用
            AutofacProvider.Container = container;
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use((context, next) => {

                var cultureQuery = context.Request.Query["culture"];
                if (!string.IsNullOrWhiteSpace(cultureQuery))
                {
                    var culture = new CultureInfo(cultureQuery);
                    CultureInfo.CurrentCulture = culture;
                }

                return next();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
