using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.DTO.SparePart;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class SparePartsController : Controller
    {
        private readonly ISparePartsService _sparePartsService;

        private static int _rowsCount = 0;
        private static int _cacheNumber = 0;
        private static bool isNameAscending = true;
        private static bool isPriceAscending = true;
        private static bool isEqTypeAscending = true;

        public SparePartsController(ISparePartsService sparePartsService)
        {
            _sparePartsService = sparePartsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _rowsCount = 20;
            return View(await _sparePartsService.Get(_rowsCount, $"SpareParts{_rowsCount}-{_cacheNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            return View("GetAll", await _sparePartsService.Get(_rowsCount, $"SpareParts{_rowsCount}-{_cacheNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            var spareParts = await _sparePartsService.Get(_rowsCount, $"ServicedStores{_rowsCount}-{_cacheNumber}");

            switch (sortedFieldNumber)
            {
                case 1:
                    if (isNameAscending)
                    {
                        isNameAscending = !isNameAscending;
                        return View("GetAll", spareParts.OrderBy(c => c.Name).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return View("GetAll", spareParts.OrderByDescending(c => c.Name).ToList());
                    }
                case 2:
                    if (isPriceAscending)
                    {
                        isPriceAscending = !isPriceAscending;
                        return View("GetAll", spareParts.OrderBy(c => c.Price).ToList());
                    }
                    else
                    {
                        isPriceAscending = !isPriceAscending;
                        return View("GetAll", spareParts.OrderByDescending(c => c.Price).ToList());
                    }
                case 3:
                    if (isEqTypeAscending)
                    {
                        isEqTypeAscending = !isEqTypeAscending;
                        return View("GetAll", spareParts.OrderBy(c => c.EquipmentType).ToList());
                    }
                    else
                    {
                        isEqTypeAscending = !isEqTypeAscending;
                        return View("GetAll", spareParts.OrderByDescending(c => c.EquipmentType).ToList());
                    }
                default:
                    return View("GetAll", spareParts);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var eqTypes = new List<string>();

            foreach (int i in Enum.GetValues(typeof(EquipmentType)))
                eqTypes.Add(EnumExtensions.GetDisplayName((EquipmentType)Enum.GetValues(typeof(EquipmentType)).GetValue(i)));

            return View(new SparePartForCreationDto
            {
                EquipmentTypes = eqTypes
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SparePartForCreationDto sparePartForCreation)
        {
            if (!ModelState.IsValid)
            {
                var eqTypes = new List<string>();

                foreach (int i in Enum.GetValues(typeof(EquipmentType)))
                    eqTypes.Add(EnumExtensions.GetDisplayName((EquipmentType)Enum.GetValues(typeof(EquipmentType)).GetValue(i)));

                return View(new SparePartForCreationDto
                {
                    EquipmentTypes = eqTypes
                });
            }

            await _sparePartsService.Create(sparePartForCreation);

            _cacheNumber++;

            return View("InfoPage");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var sparePart = await _sparePartsService.GetById(id);

            return View(new SparePartForUpdateDto
            {
                Id = id,
                Functions = sparePart.Functions,
                Price = sparePart.Price
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(SparePartForUpdateDto sparePartForUpdate)
        {
            if (!ModelState.IsValid)
            {
                var sparePart = await _sparePartsService.GetById(sparePartForUpdate.Id);

                return View(new SparePartForUpdateDto
                {
                    Id = sparePartForUpdate.Id,
                    Functions = sparePart.Functions,
                    Price = sparePart.Price
                });
            }

            bool isExists = await _sparePartsService.Update(sparePartForUpdate);

            if (!isExists)
            {
                return View();
            }

            _cacheNumber++;

            return View("InfoPage");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _sparePartsService.GetById(id);
            ViewData["Message"] = $"{entity.Name} ({entity.EquipmentType})";
            Response.Cookies.Append("sparePart_id", id.ToString());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            Request.Cookies.TryGetValue("sparePart_id", out string id);

            bool isExists = await _sparePartsService.Delete(Guid.Parse(id));

            if (!isExists)
            {
                return View();
            }

            _cacheNumber++;

            return View("InfoPage");
        }
    }
}
