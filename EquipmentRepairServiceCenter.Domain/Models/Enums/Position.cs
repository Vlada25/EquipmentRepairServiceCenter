using System.ComponentModel.DataAnnotations;

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
