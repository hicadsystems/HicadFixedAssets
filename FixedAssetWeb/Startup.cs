using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.Core.Repositories;
using FixedAssetWeb.Data;
using FixedAssetWeb.IServices;
using FixedAssetWeb.Mappings;
using FixedAssetWeb.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FixedAssetCore.IRepositories;
using FixedAssetCore.Repositories;
using System.Text.Json.Serialization;
using Wkhtmltopdf.NetCore;

namespace FixedAssetWeb
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
            services.AddWkhtmltopdf("WKHtmlToPdf");
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
           
            });
            
            services.AddDbContext<ApplicationDbContext>(options =>

            options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")
                  ));

            services.AddIdentity<User,Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMenuGroupRepository, MenuGroupRepository>();
            services.AddScoped<IMenuGroupService, MenuGroupService>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IAssetDbContext, ApplicationDbContext>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICostCenterService, CostCenterService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAssetRegisterationService, AssetRegService>();
            services.AddScoped<IBusinessLineService, BusinessLineService>();
            services.AddScoped<IAssetClassService, AssetClassService>();
            services.AddScoped<IAssetReclassificationService, AssetReclassificationService>();
            services.AddScoped<IAssetMovementService, AssetMovementService>();
            services.AddScoped<IGenerateDepreciationService, GenerateDepreciationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //In-Memory
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
            });

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddControllers().AddNewtonsoftJson();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<User> userManager, RoleManager<Role> roleManager,IConfiguration config, IUnitOfWork unitOfWork)
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

            Seeder.SeedData(userManager, roleManager, unitOfWork);


            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Authentication}/{action=Login}/{id?}");
            });
        }
    }
}
