namespace EquipmentRepairServiceCenter.DTO.RepairingModel
{
    public class RepairingModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Specifications { get; set; }
        public string ParticularQualities { get; set; }
        public string PhotoUrl { get; set; }
    }
}
