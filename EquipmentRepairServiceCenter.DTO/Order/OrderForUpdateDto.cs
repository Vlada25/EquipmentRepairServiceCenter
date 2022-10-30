namespace EquipmentRepairServiceCenter.DTO.Order
{
    public class OrderForUpdateDto
    {
        public Guid Id { get; set; }
        public DateTime EquipmentReturnDate { get; set; }
        public decimal Price { get; set; }
        public bool Guarantee { get; set; }
        public int GuaranteePeriodInMonth { get; set; }
    }
}
