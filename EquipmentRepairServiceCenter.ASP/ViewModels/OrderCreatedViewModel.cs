using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.Employee;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class OrderCreatedViewModel
    {
        // RepairingModel
        [Required(ErrorMessage = "Not specified type of repairing model")]
        public string RepairingModelType { get; set; }


        [Required(ErrorMessage = "Not specified r.m. manufacturer")]
        public string RepairingModelManufacturer { get; set; }


        [Required(ErrorMessage = "Not specified r.m. specifications")]
        public string RepairingModelSpecifications { get; set; }


        [Required(ErrorMessage = "Not specified r.m. particular qualities")]
        public string RepairingModelParticularQualities { get; set; }


        public string RepairingModelPhotoUrl { get; set; }


        public List<string> EquipmentTypes { get; set; }
        public List<string> Manufacturers { get; set; }

        // Fault
        [Required(ErrorMessage = "Not specified name of fault")]
        public string FaultName { get; set; }

        // Employee
        [Required(ErrorMessage = "Not specified information about employee")]
        public string EmployeeInfo { get; set; }

        public List<EmployeeDto> Employees { get; set; }

        // ServicedStore
        [Required(ErrorMessage = "Not specified serviced store")]
        public string ServicedStore { get; set; }

        public List<ServicedStore> ServicedStores { get; set; }
    }
}
