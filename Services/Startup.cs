using HMServices.Infrastructure;
using HMServices.Models;
using HMServices.Repositories;
using HMServices.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HMServices
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            

            if (env.IsDevelopment()) {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }
            
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup options with DI
            services.AddOptions();

            // Configure SECOptions using config by installing Microsoft.Extensions.Options.ConfigurationExtensions
            services.Configure<SECOptions>(Configuration.GetSection("SECOptions"));

            // Configure SECOptions using code
            //services.Configure<MyOptions>(myOptions =>
            //{
            //    myOptions.Option1 = "value1_from_action";
            //});

            // Configure MySubOptions using a sub-section of the appsettings.json file
            //services.Configure<MySubOptions>(Configuration.GetSection("subsection"));

            // should precede .AddMvc()
            services.AddCors();

            // Add framework services.
            services.AddMvc();

            services.AddScoped<ISymbolRepository, SymbolRepository>();
            services.AddScoped<ISECService, SECService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug(LogLevel.Trace);

            app.UseMiddleware<HttpExceptionMiddleware>();

            app.UseCors(builder =>  builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseMvc();

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
            }
        }
    }
}
