using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.SparePart;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class UsedSparePartCreatedViewModel
    {
        [Required(ErrorMessage = "Not specified fault")]
        public string Fault { get; set; }


        [Required(ErrorMessage = "Not specified spare part")]
        public string SparePart { get; set; }


        [ValidateNever]
        public List<Fault> Faults { get; set; }


        [ValidateNever]
        public List<SparePartDto> SpareParts { get; set; }
    }
}
