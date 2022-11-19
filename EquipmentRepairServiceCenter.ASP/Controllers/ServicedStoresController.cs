using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class ServicedStoresController : Controller
    {
        private readonly IServicedStoresService _servicedStoresService;

        public ServicedStoresController(IServicedStoresService servicedStoresService)
        {
            _servicedStoresService = servicedStoresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return View(await _servicedStoresService.GetAll());
        }
    }
}
