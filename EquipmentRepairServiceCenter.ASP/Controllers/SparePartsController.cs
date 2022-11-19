using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class SparePartsController : Controller
    {
        private readonly ISparePartsService _sparePartsService;

        public SparePartsController(ISparePartsService sparePartsService)
        {
            _sparePartsService = sparePartsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return View(await _sparePartsService.GetAll());
        }
    }
}
