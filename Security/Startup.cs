using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Security.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security
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
            services.AddCors(options =>
            {
                //options.AddDefaultPolicy(b =>
                //b.AllowAnyOrigin());


                options.AddPolicy("MyCors",

                    b =>
                    b.WithOrigins("https://localhost:44310", "http://localhost:44310")
                    //b.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST", "PUT")
                    /*.AllowCredentials()*/);
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("MyCors");
            //app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<SafeIpMiddleware>(Configuration["SafeIp"]);

            app.UseCSP();

            //app.UseCSP(option =>
            //{
            //    option.ScriptSources(d => d.Self().CustomSources("cdn.Ehsan.net"));
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
