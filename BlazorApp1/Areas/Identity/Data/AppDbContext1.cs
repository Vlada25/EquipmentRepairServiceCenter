using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EquipmentRepairServiceCenter.Domain.Configuration;
using EquipmentRepairServiceCenter.Domain;
using System.Reflection.Emit;

namespace BlazorApp1.Areas.Identity;

public class AppDbContext1 : IdentityDbContext<IdentityUser>
{
    public AppDbContext1(DbContextOptions<AppDbContext1> options)
        : base(options)
    {
    }

    public DbSet<Fault> Faults { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<RepairingModel> RepairingModels { get; set; }
    public DbSet<ServicedStore> ServicedStores { get; set; }
    public DbSet<SparePart> SpareParts { get; set; }
    public DbSet<UsedSparePart> UsedSpareParts { get; set; }

    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Client).WithMany().OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Employee).WithMany().OnDelete(DeleteBehavior.NoAction);
        DbInitializer.Initialize();

        modelBuilder.ApplyConfiguration(new FaultsConfig());
        modelBuilder.ApplyConfiguration(new RepairingModelsConfig());
        modelBuilder.ApplyConfiguration(new SparePartsConfig());
        modelBuilder.ApplyConfiguration(new UsedSparePartsConfig());
        modelBuilder.ApplyConfiguration(new RolesConfig());
        modelBuilder.ApplyConfiguration(new ServicedStoresConfig());
    }
}
