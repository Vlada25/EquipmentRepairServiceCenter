using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class SparePartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
