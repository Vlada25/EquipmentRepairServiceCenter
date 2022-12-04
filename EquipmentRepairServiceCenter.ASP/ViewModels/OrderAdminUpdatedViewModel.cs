using System.ComponentModel.DataAnnotations;

namespace EquipmentRepairServiceCenter.ASP.ViewModels
{
    public class OrderAdminUpdatedViewModel
    {
        [Required(ErrorMessage = "Not specified id")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Not specified equipment return date")]
        public DateTime EquipmentReturnDate { get; set; }


        [Required(ErrorMessage = "Not specified guarantee period")]
        public int GuaranteePeriodInMonth { get; set; }


        [Required(ErrorMessage = "Not specified price")]
        public decimal Price { get; set; }
    }
}
