using EquipmentRepairServiceCenter.Domain.Models.Users;

namespace EquipmentRepairServiceCenter.Domain.Models.People
{
    public abstract class Person
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public Guid UserId { get; set; }
    }
}
