using EquipmentRepairServiceCenter.DTO.RepairingModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class RepairingModelCreatedViewModel
    {
        [Required(ErrorMessage = "Not specified type")]
        public string Type { get; set; }


        [Required(ErrorMessage = "Not specified manufacturer")]
        public string Manufacturer { get; set; }


        [Required(ErrorMessage = "Not specified specifications")]
        public string Specifications { get; set; }


        [Required(ErrorMessage = "Not specified particular qualities")]
        public string ParticularQualities { get; set; }


        [ValidateNever]
        public string PhotoUrl { get; set; }


        [ValidateNever]
        public List<string> EquipmentTypes { get; set; }


        [ValidateNever]
        public List<string> Manufacturers { get; set; }
    }
}
