using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.DTO.UsedSparePart;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class UsedSparePartsController : Controller
    {
        private readonly IUsedSparePartsService _usedSparePartsService;
        private readonly IFaultsService _faultsService;
        private readonly ISparePartsService _sparePartsService;
        private static int _rowsCount = 0;

        public UsedSparePartsController(IUsedSparePartsService usedSparePartsService, 
            IFaultsService faultsService, 
            ISparePartsService sparePartsService)
        {
            _usedSparePartsService = usedSparePartsService;
            _faultsService = faultsService;
            _sparePartsService = sparePartsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _rowsCount = 20;
            return View(await _usedSparePartsService.Get(_rowsCount, $"UsedSpareParts{_rowsCount}"));
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            return View("GetAll", await _usedSparePartsService.Get(_rowsCount, $"UsedSpareParts{_rowsCount}"));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var faults = await _faultsService.GetAll();
            var spareParts = await _sparePartsService.GetAll();

            return View(new UsedSparePartCreatedViewModel
            {
                Faults = faults.ToList(),
                SpareParts = spareParts.ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsedSparePartCreatedViewModel usedSparePartCreated)
        {
            if (!ModelState.IsValid)
            {
                var faults = await _faultsService.GetAll();
                var spareParts = await _sparePartsService.GetAll();

                return View(new UsedSparePartCreatedViewModel
                {
                    Faults = faults.ToList(),
                    SpareParts = spareParts.ToList()
                });
            }

            await _usedSparePartsService.Create(new UsedSparePartForCreationDto
            {
                FaultId = Guid.Parse(usedSparePartCreated.Fault.Split(';')[0]),
                SparePartId = Guid.Parse(usedSparePartCreated.SparePart.Split(';')[0]),
            });

            return View("InfoPage");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            ViewData["Message"] = id.ToString();
            Response.Cookies.Append("usedSparePart_id", id.ToString());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            Request.Cookies.TryGetValue("usedSparePart_id", out string id);

            bool isExists = await _usedSparePartsService.Delete(Guid.Parse(id));

            if (!isExists)
            {
                return View();
            }

            return View("InfoPage");
        }
    }
}
