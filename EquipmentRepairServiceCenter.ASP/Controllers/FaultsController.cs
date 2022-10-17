using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class FaultsController : Controller
    {
        private readonly IFaultsService _faultsService;

        public FaultsController(IFaultsService faultsService)
        {
            _faultsService = faultsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var faults = await _faultsService.GetAll();

            return View(faults);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByProps(string repairingModelName, string name, string repairingMethods)
        {
            var faults = await _faultsService.GetAll();

            if (repairingModelName is null) repairingModelName = Guid.NewGuid().ToString();
            if (name is null) name = Guid.NewGuid().ToString();
            if (repairingMethods is null) repairingMethods = Guid.NewGuid().ToString();

            return View("GetAll", faults.Where(f => 
                f.RepairingModel.Name.Contains(repairingModelName, StringComparison.OrdinalIgnoreCase) ||
                f.Name.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                f.RepairingMethods.Contains(repairingMethods, StringComparison.OrdinalIgnoreCase))
                .ToList());
        }
    }
}
