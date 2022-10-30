using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.Employee;

namespace EquipmentRepairServiceCenter.ASP.LocalDto
{
    public class OrderCreatedForView
    {
        // RepairingModel
        public string RepairingModelType { get; set; }
        public string RepairingModelManufacturer { get; set; }
        public string RepairingModelSpecifications { get; set; }
        public string RepairingModelParticularQualities { get; set; }
        public string RepairingModelPhotoUrl { get; set; }
        public List<string> EquipmentTypes { get; set; }
        public List<string> Manufacturers { get; set; }

        // Fault
        public string FaultName { get; set; }

        // Employee
        public string EmployeeInfo { get; set; }
        public List<EmployeeDto> Employees { get; set; }

        // ServicedStore
        public string ServicedStore { get; set; }
        public List<ServicedStore> ServicedStores { get; set; }
    }
}
