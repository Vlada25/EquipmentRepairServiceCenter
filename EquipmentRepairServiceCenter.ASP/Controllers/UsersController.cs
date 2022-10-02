using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
