using EquipmentRepairServiceCenter.DTO.RepairingModel;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    // TODO: add data annotations
    public class RepairingModelCreatedViewModel
    {
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Specifications { get; set; }
        public string ParticularQualities { get; set; }
        public string PhotoUrl { get; set; }
        public List<string> EquipmentTypes { get; set; }
        public List<string> Manufacturers { get; set; }
    }
}
