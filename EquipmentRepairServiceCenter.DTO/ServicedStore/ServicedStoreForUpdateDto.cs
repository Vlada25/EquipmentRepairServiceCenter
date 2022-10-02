using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.DTO.ServicedStore
{
    public class ServicedStoreForUpdateDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
