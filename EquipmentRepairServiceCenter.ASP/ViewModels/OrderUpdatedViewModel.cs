using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class OrderUpdatedViewModel
    {
        [Required(ErrorMessage = "Not specified id")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Not specified repairing model name")]
        public string RepairingModelName { get; set; }


        [Required(ErrorMessage = "Not specified r.m. specifications")]
        public string RepairingModelSpecifications { get; set; }


        [Required(ErrorMessage = "Not specified r.m. particular qualities")]
        public string RepairingModelParticularQualities { get; set; }


        [Required(ErrorMessage = "Not specified name of fault")]
        public string FaultName { get; set; }


        [Required(ErrorMessage = "Not specified repairing methods")]
        public string RepairingMethods { get; set; }


        [Required(ErrorMessage = "Not specified time of repairing")]
        [Range(1, 90, ErrorMessage = "Value should be in range from 1 till 90")]
        public int RepairingTimeInDays { get; set; }


        [Required(ErrorMessage = "Not specified price")]
        [Range(0, 100000, ErrorMessage = "Value should be in range from 0 till 100000")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Not specified guarantee")]
        [Range(0, 36, ErrorMessage = "Value should be in range from 0 till 36")]
        public int GuaranteeInMonth { get; set; }
    }
}
