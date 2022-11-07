using EquipmentRepairServiceCenter.Domain.Models;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class EmployeeUpdatedViewModel
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public int WorkExperienceInYears { get; set; }
        public string ServicedStore { get; set; }


        public List<string> Positions { get; set; }
        public List<ServicedStore> ServicedStores { get; set; }
    }
}
