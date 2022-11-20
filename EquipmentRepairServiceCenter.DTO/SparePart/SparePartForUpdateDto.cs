using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.DTO.SparePart
{
    public class SparePartForUpdateDto
    {
        [Required(ErrorMessage = "Not specified id")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Not specified functions")]
        public string Functions { get; set; }


        [Required(ErrorMessage = "Not specified price")]
        [Range(0, 100000, ErrorMessage = "Value should be in range from 0 till 100000")]
        public decimal Price { get; set; }
    }
}
