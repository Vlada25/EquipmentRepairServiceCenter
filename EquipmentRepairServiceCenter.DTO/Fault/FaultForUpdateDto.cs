using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.DTO.Fault
{
    public class FaultForUpdateDto
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
    }
}
