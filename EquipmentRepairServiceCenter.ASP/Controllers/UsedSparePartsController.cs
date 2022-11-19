using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class UsedSparePartsController : Controller
    {
        private readonly IUsedSparePartsService _usedSparePartsService;

        public UsedSparePartsController(IUsedSparePartsService usedSparePartsService)
        {
            _usedSparePartsService = usedSparePartsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return View(await _usedSparePartsService.GetAll());
        }
    }
}
