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

namespace JandC
{
    public class Startup
    {
      
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddRazorPages();
            services.AddServerSideBlazor();       
            services.AddSingleton<ArticleService>();  
            //添加认证Cookie信息
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/login");
                    options.AccessDeniedPath = new PathString("/denied");
                });
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
