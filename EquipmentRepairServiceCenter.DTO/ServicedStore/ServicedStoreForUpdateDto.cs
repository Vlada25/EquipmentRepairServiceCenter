using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.DTO.ServicedStore
{
    public class ServicedStoreForUpdateDto
    {
        [Required(ErrorMessage = "Not specified id")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Not specified address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Not specified phone number")]
        public string PhoneNumber { get; set; }
    }
}
