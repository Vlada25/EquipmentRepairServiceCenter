namespace EquipmentRepairServiceCenter.DTO.Fault
{
    public class FaultForCreationDto
    {
        public string Name { get; set; }
        public Guid RepairingModelId { get; set; }
        public string RepairingMethods { get; set; }
        public decimal Price { get; set; }
    }
}
