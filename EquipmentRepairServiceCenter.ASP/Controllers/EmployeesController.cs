using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
