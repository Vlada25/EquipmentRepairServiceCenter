using EquipmentRepairServiceCenter.Domain.Models.Enums;

namespace EquipmentRepairServiceCenter.Domain.Models.People
{
    public class Employee : Person
    {
        public Position Position { get; set; }
        public int WorkExperienceInYears { get; set; }
        public Guid ServicedStoreId { get; set; }
        public ServicedStore ServicedStore { get; set; }
    }
}
