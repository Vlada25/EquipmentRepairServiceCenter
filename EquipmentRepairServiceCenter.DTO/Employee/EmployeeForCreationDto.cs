using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.DTO.Employee
{
    public class EmployeeForCreationDto
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public Guid UserId { get; set; }
        public string Position { get; set; }
        public int WorkExperienceInYears { get; set; }
        public Guid ServicedStoreId { get; set; }
    }
}
