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
    public class ServicedStoresConfig : IEntityTypeConfiguration<ServicedStore>
    {
        public void Configure(EntityTypeBuilder<ServicedStore> builder)
        {
            builder.HasData(DbInitializer.ServicedStores);
        }
    }
}
