using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class RepairingModelsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
