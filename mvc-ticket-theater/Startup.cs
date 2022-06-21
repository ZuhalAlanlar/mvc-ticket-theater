using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mvc_ticket_theater.Data;
using mvc_ticket_theater.Data.Services;
using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(@"Data Source=LAPTOP-H6EKOTV6;Initial Catalog=yenii;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));


            services.AddScoped<IActorsService, ActorsService>();
            services.AddScoped<IProducersService, ProducersService>();
            services.AddScoped<ISaloonsService, SaloonsService>();

            services.AddScoped<ITheatersService, TheatersService>();
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddMemoryCache();
            services.AddSession();
            services.AddAuthentication(options=>
            {

                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;       
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

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            AppDbInit.Seed(app);
            AppDbInit.SeedUsersAndRolesAsync(app).Wait();
        }
    }
}
