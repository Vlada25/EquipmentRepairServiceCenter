using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Domain.Models.Enums
{
    public enum Position
    {
        [Display(Name = "Engineer")]
        Engeneer,

        [Display(Name = "System engineer")]
        SystemsEngineer,

        [Display(Name = "Electronics engineer")]
        ElectronicsEngineer
    }
}
