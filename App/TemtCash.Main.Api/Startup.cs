using System;
using AspNet.Security.OAuth.Introspection;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using TemtCash.Main.Api.Infrastructure;
using TemtCash.Main.DAL;

namespace TemtCash.Main.Api
{
    // ReSharper disable once ClassNeverInstantiated.Global - initialized on startup (magically)
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }

        // ReSharper disable once UnusedMember.Global - executed on application startup
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();
            services.AddLogging();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var cs = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(cs);
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            services
                .AddAuthentication(options => options.DefaultScheme = OAuthIntrospectionDefaults.AuthenticationScheme)
                .AddOAuthIntrospection(options =>
                {
                    var oauthAuthority = Configuration.GetValue<string>("OAuthAuthority");
                    options.Authority = new Uri(oauthAuthority);
                    options.Audiences.Add("temtcash-main");
                    options.ClientId = "temtcash-main";
                    options.ClientSecret = "temtcashmain";
                    options.RequireHttpsMetadata = false;
                });

            services.RegisterDependencies();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "TemtCash.Main", Version = "v1" }));
        }

        // ReSharper disable once UnusedMember.Global - Executed on application startup
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials()); // TODO: Don't allow everything in production 
            app.UseMvcWithDefaultRoute();
            // app.UseWelcomePage(); <-- Don't use this as it breaks swagger
            app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint.

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TemtCash.Main V1"));
        }
    }
}
