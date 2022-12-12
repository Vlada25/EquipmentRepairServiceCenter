using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.DTO.UsedSparePart;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class UsedSparePartsController : Controller
    {
        private readonly IUsedSparePartsService _usedSparePartsService;
        private readonly IFaultsService _faultsService;
        private readonly ISparePartsService _sparePartsService;

        private static int _rowsCount = 0;
        private static int _cacheNumber = 0;
        private static bool isSparePartNameAscending = true;
        private static bool isFaultNameAscending = true;

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
            return View(await _usedSparePartsService.Get(_rowsCount, $"UsedSpareParts{_rowsCount}-{_cacheNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            return View("GetAll", await _usedSparePartsService.Get(_rowsCount, $"UsedSpareParts{_rowsCount}-{_cacheNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            var usedSpareParts = await _usedSparePartsService.Get(_rowsCount, $"UsedServicedStores{_rowsCount}-{_cacheNumber}");

            switch (sortedFieldNumber)
            {
                case 1:
                    if (isSparePartNameAscending)
                    {
                        isSparePartNameAscending = !isSparePartNameAscending;
                        return View("GetAll", usedSpareParts.OrderBy(c => c.SparePart.Name).ToList());
                    }
                    else
                    {
                        isSparePartNameAscending = !isSparePartNameAscending;
                        return View("GetAll", usedSpareParts.OrderByDescending(c => c.SparePart.Name).ToList());
                    }
                case 2:
                    if (isFaultNameAscending)
                    {
                        isFaultNameAscending = !isFaultNameAscending;
                        return View("GetAll", usedSpareParts.OrderBy(c => c.Fault.Name).ToList());
                    }
                    else
                    {
                        isFaultNameAscending = !isFaultNameAscending;
                        return View("GetAll", usedSpareParts.OrderByDescending(c => c.Fault.Name).ToList());
                    }
                default:
                    return View("GetAll", usedSpareParts);
            }
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

            _cacheNumber++;

            return View("InfoPage");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _usedSparePartsService.GetById(id);
            ViewData["Message"] = $"{entity.SparePart.Name} ({entity.Fault.Name})";
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

            _cacheNumber++;

            return View("InfoPage");
        }
    }
}
