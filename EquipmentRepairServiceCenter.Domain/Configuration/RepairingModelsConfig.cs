using EquipmentRepairServiceCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipmentRepairServiceCenter.Domain.Configuration
{
    public class RepairingModelsConfig : IEntityTypeConfiguration<RepairingModel>
    {
        public void Configure(EntityTypeBuilder<RepairingModel> builder)
        {
            builder.HasData(DbInitializer.RepairingModels);
        }
    }
}
