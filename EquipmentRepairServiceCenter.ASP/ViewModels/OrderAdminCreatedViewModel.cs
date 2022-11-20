using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Domain.Models.People;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class OrderAdminCreatedViewModel
    {
        public int EquipmentSerialNumber { get; set; }
        public DateTime EquipmentReturnDate { get; set; }
        public Guid ClientId { get; set; }
        public Guid FaultId { get; set; }
        public Guid ServicedStoreId { get; set; }
        public bool Guarantee { get; set; }
        public int GuaranteePeriodInMonth { get; set; }
        public decimal Price { get; set; }
        public Guid EmployeeId { get; set; }


        public List<Client> Clients { get; set; }
        public List<Fault> Faults { get; set; }
        public List<ServicedStore> ServicedStores { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
