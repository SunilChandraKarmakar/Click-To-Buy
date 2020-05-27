using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using ClickToBuy.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ClickToBuy.Manager.Contracts;
using ClickToBuy.Manager;
using ClickToBuy.Repository.Contracts;
using ClickToBuy.Repository;
using Microsoft.AspNetCore.Http;
using ClickToBuy.Database;
using AutoMapper;

namespace ClickToBuy
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<ICountryManager, CountryManager>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICityManager, CityManager>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IBrandManager, BrandManager>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IGenderManager, GenderManager>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConditionManager, ConditionManager>();
            services.AddSingleton<IConditionRepository, ConditionRepository>();
            services.AddTransient<ICloseTypeManager, CloseTypeManager>();
            services.AddSingleton<ICloseTypeRepository, CloseTypeRepository>();
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IStockProductManager, StockProductManager>();
            services.AddTransient<IStockProductRepository, StockProductRepository>();
            services.AddTransient<ISupplierManager, SupplierManager>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IPurchaseManager, PurchaseManager>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddTransient<IPurchaseItemManager, PurchaseItemManager>();
            services.AddTransient<IPurchaseItemRepository, PurchaseItemRepository>();
            services.AddTransient<IPurchasePaymentManager, PurchasePaymentManager>();
            services.AddTransient<IPurchasePaymentRepository, PurchasePaymentRepository>();
            services.AddTransient<IAdminManager, AdminManager>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<ISliderRepository, SliderRepository>();
            services.AddTransient<ISliderManager, SliderManager>();

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
