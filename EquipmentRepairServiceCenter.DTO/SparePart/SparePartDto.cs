using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.DTO.SparePart
{
    public class SparePartDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Functions { get; set; }
        public decimal Price { get; set; }
        public string EquipmentType { get; set; }
    }
}
