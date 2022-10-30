using EquipmentRepairServiceCenter.Domain.Models.Enums;

namespace EquipmentRepairServiceCenter.Domain.Models
{
    public class RepairingModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        public string Manufacturer { get; set; }
        public string Specifications { get; set; }
        public string ParticularQualities { get; set; }
        public string PhotoUrl { get; set; }
    }
}
