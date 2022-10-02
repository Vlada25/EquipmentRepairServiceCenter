using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.DTO.SparePart
{
    public class SparePartForUpdateDto
    {
        public Guid Id { get; set; }
        public string Functions { get; set; }
        public decimal Price { get; set; }
    }
}
