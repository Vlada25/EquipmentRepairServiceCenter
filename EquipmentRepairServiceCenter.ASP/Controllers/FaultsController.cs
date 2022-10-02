using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class FaultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
