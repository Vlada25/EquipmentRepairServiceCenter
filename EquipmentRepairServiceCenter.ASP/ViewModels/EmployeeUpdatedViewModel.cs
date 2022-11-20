using EquipmentRepairServiceCenter.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class EmployeeUpdatedViewModel
    {
        [Required(ErrorMessage = "Not specified id")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Not specified surname")]
        [MaxLength(30, ErrorMessage = "Max length: 30 characters")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Not specified name")]
        [MaxLength(30, ErrorMessage = "Max length: 30 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Not specified middle name")]
        [MaxLength(30, ErrorMessage = "Max length: 30 characters")]
        public string MiddleName { get; set; }


        [Required(ErrorMessage = "Not specified position")]
        public string Position { get; set; }


        [Required(ErrorMessage = "Not specified work experience")]
        [Range(0, 80, ErrorMessage = "Value should be in range from 0 till 80")]
        public int WorkExperienceInYears { get; set; }


        [Required(ErrorMessage = "Not specified serviced store")]
        public string ServicedStore { get; set; }


        [ValidateNever]
        public List<string> Positions { get; set; }

        [ValidateNever]
        public List<ServicedStore> ServicedStores { get; set; }
    }
}
