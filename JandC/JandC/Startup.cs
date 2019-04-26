using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using JandC.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net.Http;

namespace JandC
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<ArticleService>();

            //services.AddScoped<HttpClient>();
            //services.AddScoped((sp) =>
            //{
            //    return new Blazor.Auth0.Shared.Models.ClientSettings()
            //    {
            //        Auth0Domain = "[Auth0_Domain]",
            //        Auth0ClientId = "[Auth0_Client_Id]"
            //    };
            //});

            //services.AddScoped<Blazor.Auth0.ServerSide.Authentication.AuthenticationService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");

            });
        }
    }
}
