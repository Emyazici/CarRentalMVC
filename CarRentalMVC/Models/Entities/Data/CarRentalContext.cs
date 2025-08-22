
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarRentalMVC.Models.Entities.Data
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Fleet> Fleets { get; set; }
        public DbSet<FleetApplication> FleetApplications { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<DamageReport> DamageReports { get; set; }
        public DbSet<VehicleAssignmentHistory> VehicleAssignmentHistories { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<decimal>()
                .HavePrecision(18, 2);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Fleet>()
                .Property(x => x.RowVersion)
                .IsRowVersion();

            modelBuilder.Entity<FleetApplication>()
                .Property(x => x.RowVersion)
                .IsRowVersion();

            modelBuilder.Entity<Reservation>().Property(x => x.RowVersion).IsRowVersion();
            modelBuilder.Entity<DamageReport>().Property(x => x.RowVersion).IsRowVersion();

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Admin>("Admin")
                .HasValue<Customer>("Customer")
                .HasValue<FleetOwner>("FleetOwner")
                .HasValue<Staff>("Staff")              // abstract olsa da değer atanmali
                .HasValue<FleetStaff>("FleetStaff")
                .HasValue<BranchStaff>("BranchStaff");

            modelBuilder.Entity<FleetApplication>()
                .HasOne(fa => fa.Fleet)
                .WithOne(f => f.FleetApplication)
                .HasForeignKey<FleetApplication>(fa => fa.FleetId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FleetApplication>()
                    .HasIndex(a => a.FleetId)
                    .IsUnique()
            #if NET8_0_OR_GREATER
                    .HasFilter("[FleetId] IS NOT NULL"); // SQL Server
            #else
                    .HasFilter("[FleetId] IS NOT NULL");
            #endif

            modelBuilder.Entity<FleetApplication>()
                .HasOne(fa=>fa.Admin)
                .WithMany(a=>a.FleetApplications)
                .HasForeignKey(fa=>fa.AdminId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<FleetApplication>()
                .HasOne(a => a.ApplicantUser)
                .WithMany()
                .HasForeignKey(a => a.ApplicantUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FleetOwner>()
                .HasOne(fo => fo.Fleet)
                .WithOne(f => f.FleetOwner)
                .HasForeignKey<FleetOwner>(fo => fo.FleetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fleet>()
                .HasOne(f=>f.ApprovedByAdmin)
                .WithMany(a=>a.Fleets)
                .HasForeignKey(f=>f.ApprovedByAdminId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Fleet>()
                .HasMany(f => f.Branches)
                .WithOne(b => b.Fleet)
                .HasForeignKey(b=>b.FleetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fleet>()
                 .HasMany(f => f.Vehicles)
                 .WithOne(v => v.Fleet)
                 .HasForeignKey(v => v.FleetId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fleet>()
                .HasMany(f => f.FleetStaffs)
                .WithOne(fs => fs.Fleet)
                .HasForeignKey(fs => fs.FleetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Branch>()
                .HasMany(b=>b.BranchStaffs)
                .WithOne(bs=>bs.Branch)
                .HasForeignKey(bs=>bs.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Branch>()
                .HasMany(b => b.Vehicles)
                .WithOne(v => v.Branch)
                .HasForeignKey(v => v.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Branch>()
                .HasMany(b => b.ReservationsFrom)
                .WithOne(r => r.FromBranch)
                .HasForeignKey(r => r.FromBranchId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Branch>()
                .HasMany(b => b.ReservationsTo)
                .WithOne(r => r.ToBranch)
                .HasForeignKey(r => r.ToBranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Branch>()
                .HasMany(b => b.DamageReports)
                .WithOne(dr => dr.Branch)
                .HasForeignKey(dr => dr.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Branch>()
                .HasMany(b => b.VehicleAssignmentHistoriesFrom)
                .WithOne(vh => vh.FromBranch)
                .HasForeignKey(vh => vh.FromBranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Branch>()
                .HasMany(b => b.VehicleAssignmentHistoriesTo)
                .WithOne(vh => vh.ToBranch)
                .HasForeignKey(vh => vh.ToBranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasMany(v=>v.Reservations)
                .WithOne(r => r.Vehicle)
                .HasForeignKey(r=>r.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.DamageReports) 
                .WithOne(dr => dr.Vehicle)
                .HasForeignKey(dr => dr.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.VehicleAssignmentHistories)
                .WithOne(vh => vh.Vehicle)
                .HasForeignKey(vh => vh.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r=>r.Customer)
                .WithMany(c=>c.Reservations)
                .HasForeignKey(r=>r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.CreatedBy)
                .WithMany(cb=>cb.Reservations)
                .HasForeignKey(r => r.CreatedById)
                .OnDelete(DeleteBehavior.Restrict); // veya .SetNull

            modelBuilder.Entity<DamageReport>()
                .HasOne(dr => dr.CreatedBy)
                .WithMany(cb => cb.DamageReports)
                .HasForeignKey(dr => dr.CreatedById)
                .OnDelete(DeleteBehavior.Restrict); // veya .SetNull
        }
    }
}

  

