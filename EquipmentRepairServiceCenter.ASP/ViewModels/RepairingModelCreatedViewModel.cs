using EquipmentRepairServiceCenter.DTO.RepairingModel;
using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class RepairingModelCreatedViewModel
    {
        [Required(ErrorMessage = "Not specified type")]
        public string Type { get; set; }


        [Required(ErrorMessage = "Not specified manufacturer")]
        public string Manufacturer { get; set; }


        [Required(ErrorMessage = "Not specified specifications")]
        public string Specifications { get; set; }


        [Required(ErrorMessage = "Not specified particular qualities")]
        public string ParticularQualities { get; set; }


        public string PhotoUrl { get; set; }


        public List<string> EquipmentTypes { get; set; }
        public List<string> Manufacturers { get; set; }
    }
}
