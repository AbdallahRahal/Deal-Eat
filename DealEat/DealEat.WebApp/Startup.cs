using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;
using DealEat.DAL;
using DealEat.WebApp.Authentication;
using DealEat.WebApp.Controllers;
using DealEat.WebApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DealEat.WebApp
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

            services.AddOptions();

            services.AddMvc();
            services.AddSingleton(_ => new RestaurantGateway(Configuration["ConnectionStrings:DealEatDB"]));
            services.AddSingleton(_ => new ReductionGateway(Configuration["ConnectionStrings:DealEatDB"]));
            services.AddSingleton(_ => new UserGateway(Configuration["ConnectionStrings:DealEatDB"]));
            services.AddSingleton<PasswordHasher>();
            services.AddSingleton<UserService>();
            services.AddSingleton<TokenService>();
            services.AddSingleton<GoogleAuthenticationManager>();



            services.Configure<SpaOptions>(o =>
            {
                o.Host = Configuration["Spa:Host"];
            });

            services.AddAuthentication(CookieAuthentication.AuthenticationScheme)
                .AddCookie(CookieAuthentication.AuthenticationScheme, o =>
                {
                    o.ExpireTimeSpan = TimeSpan.FromHours(1);
                    o.SlidingExpiration = true;
                });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowCredentials();
                c.WithOrigins(Configuration["Spa:Host"]);
                c.WithOrigins("http://localhost/5000");
            });
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
