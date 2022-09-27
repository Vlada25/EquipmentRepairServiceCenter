using EquipmentRepairServiceCenter.Domain.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int EquipmentSerialNumber { get; set; }
        public DateTime EquipmentReturnDate { get; set; }
        public Guid ClientId { get; set; }
        public Guid FaultId { get; set; }
        public Guid ServicedStoreId { get; set; }
        public bool Guarantee { get; set; }
        public int GuaranteePeriodInMonth { get; set; }
        public decimal Price { get; set; }
        public Guid EmployeeId { get; set; }

        public Client Client { get; set; }
        public Fault Fault { get; set; }
        public ServicedStore ServicedStore { get; set; }
        public Employee Employee { get; set; }
    }
}
