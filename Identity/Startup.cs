using Identity.Helpers;
using Identity.Data;
using Identity.Helpers;
using Identity.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity
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


            // services.AddDbContext<DataBaseContext>(
            // p => p.UseSqlServer
            // ("Data Source=.;Initial Catalog=identitydb;Integrated Security=True;MultipleActiveResultSets=true"));
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "";
                    options.ClientSecret = "";
                }
                );

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<DataBaseContext>()
                .AddDefaultTokenProviders()
                .AddRoles<Role>()
                .AddErrorDescriber<CustomIdentityError>()
                .AddPasswordValidator<MyPasswordValidator>();

            services.Configure<IdentityOptions>(option =>
            {
                //UserSetting
                //option.User.AllowedUserNameCharacters = "abcd123";
                option.User.RequireUniqueEmail = true;

                //Password Setting
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;//!@#$%^&*()_+
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 8;
                option.Password.RequiredUniqueChars = 1;

                //Lokout Setting
                option.Lockout.MaxFailedAccessAttempts = 3;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(10);

                //SignIn Setting
                option.SignIn.RequireConfirmedAccount = false;
                option.SignIn.RequireConfirmedEmail = false;
                option.SignIn.RequireConfirmedPhoneNumber = false;

            });


            services.ConfigureApplicationCookie(option =>
            {
                // cookie setting
                option.ExpireTimeSpan = TimeSpan.FromMinutes(10);

                option.LoginPath = "/account/login";
                option.AccessDeniedPath = "/Account/AccessDenied";
                option.SlidingExpiration = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminUsers", policy =>
                {
                    policy.RequireRole("Admin");
                });

                options.AddPolicy("Buyer", policy =>
                {
                    policy.RequireClaim("Buyer");
                });
                options.AddPolicy("BloodType", policy =>
                {
                    policy.RequireClaim("Blood", "Ap", "Op");
                }
                );
                options.AddPolicy("Cradit", policy =>
                {
                    policy.Requirements.Add(new UserCreditRequerment(10000));
                });
                options.AddPolicy("IsBlogForUser", policy =>
                {
                    policy.AddRequirements(new BlogRequirement());
                });
            });

            //services.AddScoped<IUserClaimsPrincipalFactory<User>, AddMyClaims>();
            services.AddScoped<IClaimsTransformation, AddClaim>();
            services.AddSingleton<IAuthorizationHandler, UserCreditHandler>();
            services.AddSingleton<IAuthorizationHandler, IsBlogForUserAuthorizationHandler>();

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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
