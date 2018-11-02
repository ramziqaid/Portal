using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalAPI.Areas.Order.Data.Model;
using PortalAPI.Models;

namespace PortalAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Amendment> Amendment { get; set; }

        public DbSet<RequestType> RequestType { get; set; }

        public DbSet<PortalAPI.Areas.Order.Data.Model.AmendmentReason> AmendmentReason { get; set; }

    }
}
