using EquipmentRepairServiceCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
