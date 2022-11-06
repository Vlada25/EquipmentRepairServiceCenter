namespace EquipmentRepairServiceCenter.DTO.RepairingModel
{
    public class RepairingModelForUpdateDto
    {
        public Guid Id { get; set; }
        public string Specifications { get; set; }
        public string ParticularQualities { get; set; }
        public string PhotoUrl { get; set; }
    }
}
