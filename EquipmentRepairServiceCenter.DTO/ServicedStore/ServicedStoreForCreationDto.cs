using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.DTO.ServicedStore
{
    public class ServicedStoreForCreationDto
    {
        [Required(ErrorMessage = "Not specified name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Not specified address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Not specified phone number")]
        public string PhoneNumber { get; set; }
    }
}
