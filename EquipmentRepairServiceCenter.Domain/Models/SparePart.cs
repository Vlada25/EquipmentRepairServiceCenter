using EquipmentRepairServiceCenter.Domain.Models.Enums;

namespace EquipmentRepairServiceCenter.Domain.Models
{
    public class SparePart
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Functions { get; set; }
        public decimal Price { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}
