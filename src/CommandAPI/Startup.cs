using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CommandAPI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CommandAPI
{
    public class Startup
    {
          public IConfiguration Configuration {get;} // a kind of dependency injection? assess to the configuration api, via implementation of interface
          public Startup(IConfiguration configuration)
        {
          Configuration = configuration;
        }




        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddDbContext<CommandContext>(opt => opt.UseNpgsql
       (Configuration.GetConnectionString("PostgreSqlConnection")));// register DbContext, pass connetion string via configuration API

            services.AddControllers();//registers sercices to enable the use of Controllers

            //services.AddScoped <ICommandAPIRepo,MockCommandAPIRepo>();// register IcommandAPIRepo and Mock...
            services.AddScoped<ICommandAPIRepo,SqlCommandAPIRepo> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();//map controllers to our endpoints
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });
            });
        }
    }
}
