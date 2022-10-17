using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StartPage()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminsPage()
        {
            return View();
        }
    }
}
