﻿using System.Threading.Tasks;
using KDBS.Areas.Identity;
using KDBS.Data;
using KDBS.Services.CategoryService;
using KDBS.Services.CompanyService;
using KDBS.Services.GeocodingService;
using KDBS.Services.GoodsService;
using KDBS.Services.JobService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KDBS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<UserModel>(o =>
                {
                    o.SignIn.RequireConfirmedAccount = false;
                    o.Password.RequireDigit = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequiredLength = 4;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpContextAccessor();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<UserModel>>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IGoodsService, GoodsService>();
            services.AddScoped<IGeocodingService, GeocodingService>();

            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            UserManager<UserModel> userManager,
            ICompanyService companyService,
            RoleManager<IdentityRole> roleManager
        )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            Task.Run(() => CreateRolesAndUsers(userManager, roleManager, companyService)).Wait();
        }

        private async Task CreateRolesAndUsers(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager, ICompanyService companyService)
        {
            var adminExist = await roleManager.RoleExistsAsync("Admin");

            if (!adminExist)
            {
                var role = new IdentityRole { Name = "Admin" };
                await roleManager.CreateAsync(role);

                // Todo Change admin email and password
                var user = new UserModel { FirstName = "Admin", LastName = "Admin", UserName = "Administrator", Email = "admin@rasmusdavidsen.com" };
                var userPWD = "test123";

                var chkUser = await userManager.CreateAsync(user, userPWD);

                if (chkUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");

                    var address = "Telegrafvej 9";
                    var zipcode = 2750;

                    var company = new CompanyModel
                    {
                        Name = "Admins A/S",
                        Address = address,
                        City = "Ballerup",
                        ZipCode = zipcode,
                        User = user,
                        Latitude = 55.733336,
                        Longitude = 12.343428
                    };
                    await companyService.CreateCompany(company);
                }
            }

            var recruiterExist = await roleManager.RoleExistsAsync("Recruiter");
            if (!recruiterExist)
            {
                var role = new IdentityRole { Name = "Recruiter" };
                await roleManager.CreateAsync(role);
            }
        }
    }
}
