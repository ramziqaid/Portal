using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using Portal.Models;
using Portal.Services;  
using PortalAspCore.Data;
using EfCoreGenericRepository;
using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Repository;
using Portal.Data;

namespace Portal
{
    public class Startup
    {
        //private IConfigurationRoot _configurationRoot;
        //public Startup(IHostingEnvironment hostingEnvironment)
        //{
        //    _configurationRoot = new ConfigurationBuilder()
        //        .SetBasePath(hostingEnvironment.ContentRootPath)
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //}

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PlutoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<PlutoContext>()
            //    .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<IRequestTypeRepository, RequestTypeRepository>();
            services.AddTransient<IAmendmentRepository, AmendmentRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<IHousingRepository, HousingRepository>();
            services.AddTransient<IEmployeeInfoViewRepository, EmployeeInfoViewRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
          

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                app.UseSession();
                app.UseIdentity();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                       name: "areas",
                       template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                     );
                routes.MapRoute(  
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                    //template: "{controller=EForm}/{action=List}/{id?}");
            });
           DbInitializer.Seed(app);
        }
    }
}
