using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftShop.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DAL.Models;
using BLL.Services;
using DAL.Repositories;
using BLL.Models;
using AutoMapper;
using BLL;
using Microsoft.Extensions.FileProviders;
using System.IO;
using GiftShop.Areas.ProductList.Controllers;
using Microsoft.AspNetCore.Identity.UI.Services;
using GiftShop.Infrastructure;

namespace GiftShop
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IService<OrderDTO>, OrderService>();
            services.AddScoped<IService<OrderStatusDTO>, OrderStatusService>();
            services.AddScoped<IService<OrderGoodsDTO>, OrderGoodsService>();
            services.AddScoped<IService<GroupDTO>, GroupService>();
            services.AddScoped<IService<GoodsDTO>, GoodsService>();
            services.AddScoped<IService<PropertyDTO>, PropertyService>();
            services.AddScoped<IService<CartGoodsDTO>, CartItemService>();
            services.AddScoped<IService<ImageDTO>, ImageService>();
            services.AddScoped<IServiceUsers<UserDTO>, UserService>();
            services.AddScoped<IRepository<Goods>, GoodsRepository>();
            services.AddScoped<IRepository<Group>, GroupRepository>();
            services.AddScoped<IRepository<GoodsImage>, GoodsImageRepository>();
            services.AddScoped<IRepository<Image>, ImageRepository>();
            services.AddScoped<IRepository<Charact>, CharactRepository>();
            services.AddScoped<IRepository<OrderGoods>, OrderGoodsRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<Property>, PropertyRepository>();
            services.AddScoped<IRepository<CartItem>, CartItemRepository>();
            services.AddScoped<IRepository<OrderStatus>, OrderStatusRepository>();
            services.AddScoped<IRepository<AspNetUsers>, UserRepository>();

            services.AddDbContext<GiftShopContext>( options =>
            options.UseSqlServer(Configuration.GetConnectionString("GiftShopConnection")), ServiceLifetime.Transient);

            services.AddScoped<DataManager>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("GiftShopConnection")));

            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //        services.AddIdentity<IdentityUser, IdentityRole>()
            //.AddRoleManager<RoleManager<IdentityRole>>()
            //.AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddRoleManager<RoleManager<IdentityRole>>()
                    .AddDefaultUI()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();


            //services.AddIdentity<IdentityUser, IdentityRole>()
            //      .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<IEmailSender, DevEmailSender>();
            services.AddTransient<IEmailSender, MailSender>();
            //services.AddScoped(sp => CartController.GetCart(sp));
            //services.AddScoped(sp => TestSession.GetCart(sp));

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            //services.AddDistributedMemoryCache();
            //services.AddSession(options =>
            //{
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            //});

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
