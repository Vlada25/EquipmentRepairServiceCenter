using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.DTO.SparePart
{
    public class SparePartForCreationDto
    {
        [Required(ErrorMessage = "Not specified name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Not specified functions")]
        public string Functions { get; set; }


        [Required(ErrorMessage = "Not specified price")]
        [Range(0, 100000, ErrorMessage = "Value should be in range from 0 till 100000")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Not specified equipment type")]
        public string EquipmentType { get; set; }


        [ValidateNever]
        public List<string> EquipmentTypes { get; set; }
    }
}
