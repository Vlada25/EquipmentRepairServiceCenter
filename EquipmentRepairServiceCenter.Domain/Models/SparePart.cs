using EquipmentRepairServiceCenter.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Domain.Models
{
    public class SparePart
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Functions { get; set; }
        public decimal Price { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}
