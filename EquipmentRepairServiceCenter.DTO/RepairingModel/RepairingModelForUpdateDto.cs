using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.DTO.RepairingModel
{
    public class RepairingModelForUpdateDto
    {
        [Required(ErrorMessage = "Not specified id")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Not specified name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Not specified specifications")]
        public string Specifications { get; set; }


        [Required(ErrorMessage = "Not specified particular qualities")]
        public string ParticularQualities { get; set; }


        public string PhotoUrl { get; set; }
    }
}
