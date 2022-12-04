using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.Domain;
using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.DTO.RepairingModel;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    //[Authorize]
    public class RepairingModelsController : Controller
    {
        private readonly IRepairingModelsService _repairingModelsService;

        private static int _rowsCount = 0;
        private static int _cacheNumber = 0;
        private static bool isNameAscending = true;
        private static bool isManufacturerAscending = true;

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
            _rowsCount = 20;
            var repairingModels = await _repairingModelsService.Get(_rowsCount, $"RepairingModels{_rowsCount}-{_cacheNumber}");

            return View(repairingModels);
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            var repairingModels = await _repairingModelsService.Get(_rowsCount, $"RepairingModels{_rowsCount}-{_cacheNumber}");

            return View("GetAll", repairingModels);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            var repairingModels = await _repairingModelsService.Get(_rowsCount, $"RepairingModels{_rowsCount}-{_cacheNumber}");

            switch (sortedFieldNumber)
            {
                case 1:
                    if (isNameAscending)
                    {
                        isNameAscending = !isNameAscending;
                        return View("GetAll", repairingModels.OrderBy(c => c.Name).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return View("GetAll", repairingModels.OrderByDescending(c => c.Name).ToList());
                    }
                case 2:
                    if (isManufacturerAscending)
                    {
                        isManufacturerAscending = !isManufacturerAscending;
                        return View("GetAll", repairingModels.OrderBy(c => c.Manufacturer).ToList());
                    }
                    else
                    {
                        isManufacturerAscending = !isManufacturerAscending;
                        return View("GetAll", repairingModels.OrderByDescending(c => c.Manufacturer).ToList());
                    }
                default:
                    return View("GetAll", repairingModels);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<string> eqTypes = new List<string>();

            foreach (int i in Enum.GetValues(typeof(EquipmentType)))
                eqTypes.Add(EnumExtensions.GetDisplayName((EquipmentType)Enum.GetValues(typeof(EquipmentType)).GetValue(i)));

            return View(new RepairingModelCreatedViewModel
            {
                EquipmentTypes = eqTypes,
                Manufacturers = DbInitializer.Manufacturers.ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(RepairingModelCreatedViewModel repairingModelCreated)
        {
            if (!ModelState.IsValid)
            {
                List<string> eqTypes = new List<string>();

                foreach (int i in Enum.GetValues(typeof(EquipmentType)))
                    eqTypes.Add(EnumExtensions.GetDisplayName((EquipmentType)Enum.GetValues(typeof(EquipmentType)).GetValue(i)));

                return View(new RepairingModelCreatedViewModel
                {
                    EquipmentTypes = eqTypes,
                    Manufacturers = DbInitializer.Manufacturers.ToList()
                });
            }

            await _repairingModelsService.Create(new RepairingModelForCreationDto
            {
                Name = repairingModelCreated.Type + " " + repairingModelCreated.Manufacturer,
                Type = repairingModelCreated.Type,
                Manufacturer = repairingModelCreated.Manufacturer,
                Specifications = repairingModelCreated.Specifications,
                ParticularQualities = repairingModelCreated.ParticularQualities,
                PhotoUrl = repairingModelCreated.PhotoUrl
            });

            _cacheNumber++;

            return View("InfoPage");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var repairingModel = await _repairingModelsService.GetById(id);

            return View(new RepairingModelForUpdateDto
            {
                Id = id,
                Specifications = repairingModel.Specifications,
                ParticularQualities = repairingModel.ParticularQualities,
                PhotoUrl = repairingModel.PhotoUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RepairingModelForUpdateDto repairingModelUpdated)
        {
            if (!ModelState.IsValid)
            {
                var repairingModel = await _repairingModelsService.GetById(repairingModelUpdated.Id);

                return View(new RepairingModelForUpdateDto
                {
                    Id = repairingModelUpdated.Id,
                    Specifications = repairingModel.Specifications,
                    ParticularQualities = repairingModel.ParticularQualities,
                    PhotoUrl = repairingModel.PhotoUrl
                });
            }

            bool isExists = await _repairingModelsService.Update(repairingModelUpdated);

            if (!isExists)
            {
                ViewData["Message"] = "Repairing model not found!";
                return View();
            }

            _cacheNumber++;

            return View("InfoPage");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            ViewData["Message"] = id.ToString();
            Response.Cookies.Append("repairingModel_id", id.ToString());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            Request.Cookies.TryGetValue("repairingModel_id", out string id);

            bool isExists = await _repairingModelsService.Delete(Guid.Parse(id));

            if (!isExists)
            {
                return View();
            }

            _cacheNumber++;

            return View("InfoPage");
        }
    }
}
