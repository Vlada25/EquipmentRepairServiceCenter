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
    [Authorize]
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

        [HttpGet]
        public async Task<IActionResult> GetAllForUpdate()
        {
            var repairingModels = await _repairingModelsService.GetAll();

            return View(repairingModels);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByProps_Update(string name)
        {
            var repairingModels = await _repairingModelsService.GetAll();

            return View("GetAllForUpdate", repairingModels.Where(f =>
                f.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForDelete()
        {
            var repairingModels = await _repairingModelsService.GetAll();

            return View(repairingModels);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByProps_Delete(string name)
        {
            var repairingModels = await _repairingModelsService.GetAll();

            return View("GetAllForDelete", repairingModels.Where(f =>
                f.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList());
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
                return View();
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

            return View("InfoPage");
        }

        [HttpGet]
        [Authorize(Roles = "Employee")]
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
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Update(RepairingModelForUpdateDto repairingModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isExists = await _repairingModelsService.Update(repairingModel);

            if (!isExists)
            {
                ViewData["Message"] = "Repairing model not found!";
                return View();
            }

            return View("InfoPage");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isExists = await _repairingModelsService.Delete(id);

            if (!isExists)
            {
                return View();
            }

            return View("InfoPage");
        }
    }
}
