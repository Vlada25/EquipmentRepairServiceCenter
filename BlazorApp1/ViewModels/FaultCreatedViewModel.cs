using EquipmentRepairServiceCenter.DTO.RepairingModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class FaultCreatedViewModel
    {
        [Required(ErrorMessage = "Not specified name")]
        [MaxLength(100, ErrorMessage = "Max length: 100 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Not specified repairing model")]
        public string RepairingModel { get; set; }


        [Required(ErrorMessage = "Not specified repairing methods")]
        public string RepairingMethods { get; set; }


        [Required(ErrorMessage = "Not specified price")]
        [Range(0, 100000, ErrorMessage = "Value should be in range from 0 till 100000")]
        public decimal Price { get; set; }


        [ValidateNever]
        public List<RepairingModelDto> RepairingModels { get; set; }
    }
}
