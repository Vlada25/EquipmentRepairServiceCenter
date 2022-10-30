using EquipmentRepairServiceCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipmentRepairServiceCenter.Domain.Configuration
{
    public class ServicedStoresConfig : IEntityTypeConfiguration<ServicedStore>
    {
        public void Configure(EntityTypeBuilder<ServicedStore> builder)
        {
            builder.HasData(DbInitializer.ServicedStores);
        }
    }
}
