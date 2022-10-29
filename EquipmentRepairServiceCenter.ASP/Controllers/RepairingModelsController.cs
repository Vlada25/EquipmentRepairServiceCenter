using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class RepairingModelsController : Controller
    {
        private readonly IRepairingModelsService _repairingModelsService;

        public RepairingModelsController(IRepairingModelsService repairingModelsService)
        {
            _repairingModelsService = repairingModelsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var repairingModel = await _repairingModelsService.GetById(id);

            return View(repairingModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var repairingModels = await _repairingModelsService.GetAll();

            return View(repairingModels);
        }
    }
}
