using System;
using System.Text;
using ITI.PrimarySchool.DAL;
using ITI.PrimarySchool.WebApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ITI.PrimarySchool.WebApp
{
    public class Startup
    {
        readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string secretKey = _configuration["JwtBearer:SigningKey"];
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            services.Configure<GatewayOptions>(options =>
            {
                options.ConnectionString = _configuration["ConnectionStrings:PrimarySchool"];
            });

            services.Configure<TokenProviderOptions>(options =>
            {
                options.Audience = _configuration["JwtBearer:Audience"];
                options.Issuer = _configuration["JwtBearer:Issuer"];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            services.AddMvc();
            services.AddSingleton<ClassGateway>();
            services.AddSingleton<TeacherGateway>();
            services.AddSingleton<AuthenticationGateway>();
            services.AddSingleton<PasswordHasher>();
            services.AddSingleton<TokenService>();

            services.AddAuthentication()
                .AddJwtBearer(JwtBearerAuthentication.AuthenticationType, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,

                        ValidateIssuer = true,
                        ValidIssuer = _configuration["JwtBearer:Issuer"],

                        ValidateAudience = true,
                        ValidAudience = _configuration["JwtBearer:Audience"],

                        AuthenticationType = JwtBearerAuthentication.AuthenticationType,

                        ValidateLifetime = true
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(b =>
            {
                b.AllowAnyHeader()
                 .AllowCredentials()
                 .AllowAnyMethod()
                 .WithOrigins(_configuration["Spa:Url"]);
            });

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}
