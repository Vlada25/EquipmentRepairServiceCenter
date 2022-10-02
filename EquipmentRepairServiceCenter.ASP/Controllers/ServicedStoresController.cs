using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class ServicedStoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
