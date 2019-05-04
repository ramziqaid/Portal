//Copyright 2017 (c) SmartIT. All rights reserved. By John Kocer
using System;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfCoreGenericRepository.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EfCoreGenericRepository
{
    public class PlutoContext : DbContext
    {
        public PlutoContext(DbContextOptions<PlutoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EmployeeInfoView>(entity =>
            {
                entity.HasKey(e => e.EmployeeID);
                entity.ToTable("ESS_EmployeeInfoView2");
                entity.Property(e => e.EmployeeID).HasMaxLength(50);
            });

            builder.Entity<BankInfo>()
             .HasKey(lc => new { lc.WORKER});

            // builder.Ignore<EmployeeInfoView>();
        }

        public virtual void Save()
        {
            base.SaveChanges();
        }

        public string UserProvider
        {
            get
            {
                if (!string.IsNullOrEmpty(WindowsIdentity.GetCurrent().Name))
                    return WindowsIdentity.GetCurrent().Name.Split('\\')[1];
                return string.Empty;
            }
        }

        public Func<DateTime> TimestampProvider { get; set; } = ()
            => DateTime.UtcNow;
        public override int SaveChanges()
        {
            TrackChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            TrackChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void TrackChanges()
        {
            //foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            //{
            //    if (entry.Entity is IAuditable)
            //    {
            //        var auditable = entry.Entity as IAuditable;
            //        if (entry.State == EntityState.Added)
            //        {
            //            auditable.CreatedBy = UserProvider;//
            //            auditable.CreatedOn = TimestampProvider();
            //            auditable.UpdatedOn = TimestampProvider();
            //        }
            //        else
            //        {
            //            auditable.UpdatedBy = UserProvider;
            //            auditable.UpdatedOn = TimestampProvider();
            //        }
            //    }
            //}
        }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Amendment> Amendments { get; set; }

        public DbSet<RequestType> RequestTypes { get; set; }

        public DbSet<AmendmentReason> AmendmentReasons { get; set; }

        public virtual DbSet<EmployeeInfoView> EmployeeInfoView { get; set; }

        public DbSet<Housing> Housings { get; set; }

        public DbSet<ESS_GetOrder> eSS_GetOrders { get; set; }

        //Dyanmic AX
        public DbSet<BankInfo> bankInfos { get; set; }

    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<PlutoContext>
    {
        public PlutoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PlutoContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Database=MicrosoftDynamicsAX2;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new PlutoContext(optionsBuilder.Options);
        }
    }
}