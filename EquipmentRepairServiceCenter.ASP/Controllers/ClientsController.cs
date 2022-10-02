using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
