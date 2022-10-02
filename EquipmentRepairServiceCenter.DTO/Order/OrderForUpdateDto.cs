using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.DTO.Order
{
    public class OrderForUpdateDto
    {
        public Guid Id { get; set; }
        public DateTime EquipmentReturnDate { get; set; }
        public decimal Price { get; set; }
    }
}
