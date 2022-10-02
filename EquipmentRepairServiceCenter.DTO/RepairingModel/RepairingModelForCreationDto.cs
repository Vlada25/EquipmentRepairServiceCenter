using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.DTO.RepairingModel
{
    public class RepairingModelForCreationDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Specifications { get; set; }
        public string ParticularQualities { get; set; }
        public string PhotoUrl { get; set; }
    }
}
