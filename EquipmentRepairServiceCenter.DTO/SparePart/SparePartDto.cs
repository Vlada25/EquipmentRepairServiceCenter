namespace EquipmentRepairServiceCenter.DTO.SparePart
{
    public class SparePartDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Functions { get; set; }
        public decimal Price { get; set; }
        public string EquipmentType { get; set; }
    }
}
