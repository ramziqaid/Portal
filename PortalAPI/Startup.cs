﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreGenericRepository;
using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 
using PortalAPI.Models;

namespace PortalAPI
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
            services.AddDbContext<PlutoContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
             

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<PlutoContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            
            services.AddTransient<IRequestTypeRepository, RequestTypeRepository>();
            services.AddTransient<IAmendmentRepository, AmendmentRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<IEmployeeInfoViewRepository, EmployeeInfoViewRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            

            //services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
