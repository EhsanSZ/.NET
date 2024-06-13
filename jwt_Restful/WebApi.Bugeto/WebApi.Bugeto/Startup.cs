using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApi.Bugeto.Models.Contexts;
using WebApi.Bugeto.Models.Services;
using WebApi.Bugeto.Models.Services.Validator;

namespace WebApi.Bugeto
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

            services.AddControllers();
            services.AddScoped<ITokenValidator, TokenValidate>();
           

            services.AddAuthentication(Options =>
            {
                Options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(configureOptions =>
            {
                configureOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = Configuration["JWtConfig:issuer"],
                    ValidAudience = Configuration["JWtConfig:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWtConfig:Key"])),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                };
                configureOptions.SaveToken = true; // HttpContext.GetTokenAsunc();
                configureOptions.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                     {
                         //log 
                         //........
                         return Task.CompletedTask;
                     },
                    OnTokenValidated = context =>
                     {
                         //log
                         var tokenValidatorService = context.HttpContext.RequestServices.GetRequiredService<ITokenValidator>();
                         return tokenValidatorService.Execute(context);

                     },
                    OnChallenge = context =>
                     {
                         return Task.CompletedTask;

                     },
                    OnMessageReceived = context =>
                     {
                         return Task.CompletedTask;

                     },
                    OnForbidden = context =>
                    {
                        return Task.CompletedTask;

                    }
                };

            });


            string connection = "Data Source=.;Initial Catalog=WebApi;Integrated Security=True;MultipleActiveResultSets=true";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));
            services.AddScoped<TodoRepository, TodoRepository>();
            services.AddScoped<CategoryRepository, CategoryRepository>();
            services.AddScoped<UserRepository, UserRepository>();
            services.AddScoped<UserTokenRepository, UserTokenRepository>();

            services.AddApiVersioning( Options=>
            {
                Options.AssumeDefaultVersionWhenUnspecified = true;
                Options.DefaultApiVersion = new ApiVersion(1, 0);
                Options.ReportApiVersions = true;
            });

            services.AddSwaggerGen(c =>
            {

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WebApi.Bugeto.xml"), true);


                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi.Bugeto", Version = "v1" });
                //c.SwaggerDoc("v2", new OpenApiInfo { Title = "WebApi.Bugeto", Version = "v2" });


                //c.DocInclusionPredicate((doc, apiDescription) =>
                //{
                //    if (!apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                //    var version = methodInfo.DeclaringType
                //        .GetCustomAttributes<ApiVersionAttribute>(true)
                //        .SelectMany(attr => attr.Versions);

                //    return version.Any(v => $"v{v.ToString()}" == doc);
                //});

                var security = new OpenApiSecurityScheme
                {
                    Name = "JWT Auth",
                    Description = "توکن خود را وارد کنید- دقت کنید فقط توکن را وارد کنید",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(security.Reference.Id, security);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { security , new string[]{ } }
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    //options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}



 