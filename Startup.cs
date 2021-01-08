using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shts_BusinessLogic;
using Shts_BusinessLogic.BusinessLogic_Interfaces;
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_BusinessLogic.Collections;
using Shts_BusinessLogic.Managers;
using Shts_BusinessLogic.Models;
using Shts_Interfaces.BusinessLogic;

namespace SelfHelpTicketingSystem
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
            services.AddControllersWithViews();

            //Inject dependencies to controllers.
            //AddScoped: Objects are the same within a request, but different across different requests. I picked scoped because I find transient to be overkill.
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IUserCollection, UserCollection>();
            services.AddScoped<ICredentialsManager, CredentialsManager>();
            services.AddScoped<ITicketCollection, TicketCollection>();
            services.AddScoped<ICommentCollection, CommentCollection>();
            services.AddScoped<IUser, User>();
            services.AddScoped<ITicket, Ticket>();
            services.AddScoped<IComment, Comment>();
            



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                options =>
                {
                    options.LoginPath = "/Authentication/Login";
                    options.Cookie.Name = "SHTSCookie";
                    options.LogoutPath = "/Authentication/SignOut";

                }
            );
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
                    name: "default",
                    pattern: "{controller=Authentication}/{action=Login}/{id?}");
            });
        }
    }
}
