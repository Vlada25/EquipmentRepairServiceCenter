using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class ExpandedUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Role { get; set; }
    }
}
