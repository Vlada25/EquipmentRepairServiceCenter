using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.DTO.Employee;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class OrdersClientsEmployeesViewModel
    {
        public List<Order> Orders { get; set; }
        public List<Client> Clients { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}
