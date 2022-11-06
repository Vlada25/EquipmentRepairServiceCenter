using EquipmentRepairServiceCenter.DTO.RepairingModel;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class FaultCreatedViewModel
    {
        public string Name { get; set; }
        public string RepairingModel { get; set; }
        public string RepairingMethods { get; set; }
        public decimal Price { get; set; }

        public List<RepairingModelDto> RepairingModels { get; set; }
    }
}
