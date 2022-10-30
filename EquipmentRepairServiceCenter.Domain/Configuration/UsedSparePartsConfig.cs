using EquipmentRepairServiceCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipmentRepairServiceCenter.Domain.Configuration
{
    public class UsedSparePartsConfig : IEntityTypeConfiguration<UsedSparePart>
    {
        public void Configure(EntityTypeBuilder<UsedSparePart> builder)
        {
            builder.HasData(DbInitializer.UsedSpareParts);
        }
    }
}
