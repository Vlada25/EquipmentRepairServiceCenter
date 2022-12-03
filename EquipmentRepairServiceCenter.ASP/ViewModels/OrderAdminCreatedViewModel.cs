using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.DTO.Employee;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class OrderAdminCreatedViewModel
    {
        [Required(ErrorMessage = "Not specified equipment serial number")]
        [Range(1000000, 10000000, ErrorMessage = "Value should be in range from 1000000 till 10000000")]
        public int EquipmentSerialNumber { get; set; }


        [Required(ErrorMessage = "Not specified equipment return date")]
        public DateTime EquipmentReturnDate { get; set; }


        [Required(ErrorMessage = "Not specified client")]
        public string Client { get; set; }


        [Required(ErrorMessage = "Not specified employee")]
        public string Employee { get; set; }


        [Required(ErrorMessage = "Not specified fault")]
        public string Fault { get; set; }


        [Required(ErrorMessage = "Not specified serviced store")]
        public string ServicedStore { get; set; }


        [Required(ErrorMessage = "Not specified guarantee period")]
        public int GuaranteePeriodInMonth { get; set; }


        [Required(ErrorMessage = "Not specified price")]
        public decimal Price { get; set; }


        [ValidateNever]
        public List<Client> Clients { get; set; }

        [ValidateNever]
        public List<Fault> Faults { get; set; }

        [ValidateNever]
        public List<ServicedStore> ServicedStores { get; set; }

        [ValidateNever]
        public List<EmployeeDto> Employees { get; set; }
    }
}
