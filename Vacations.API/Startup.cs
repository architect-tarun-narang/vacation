using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Vacations.API.Contexts;
using Vacations.API.Extensions;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Hosting;

namespace Vacations.API
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
            //This is for AppMetrics, Prometheus and Grafana, it may not be required but in case it throws errors 
            //this code is necessary.

            services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });
            services.AddMetrics();

            var key = new byte[10];
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            #region System-Services
            
            // Adding assemblies will read any profiles defined in a project.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration);

            // Creating policies that wraps the authorization requirements
            services.AddAuthorization();

            services.AddCors(o => o.AddPolicy("default", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


            /*            services.AddScoped<IConfigurationBuilder, ConfigurationBuilder>();
                                    services.AddAuthentication(x =>
                        {
                            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        })
                            .AddJwtBearer(x =>
                            {
                                x.RequireHttpsMetadata = false;
                                x.SaveToken = true;

                            });

            */
            ServiceExtension.RegisterServices(services);
            
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
                app.UseHsts();
            }
            //app.UseRouting();
            app.UseCors("default");
            app.UseHttpsRedirection();            
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMvc();
            
        }
    }
}
