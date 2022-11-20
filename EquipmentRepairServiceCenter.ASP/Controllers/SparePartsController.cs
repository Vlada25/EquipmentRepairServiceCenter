using EquipmentRepairServiceCenter.ASP.Services;
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

        public SparePartsController(ISparePartsService sparePartsService)
        {
            _sparePartsService = sparePartsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return View(await _sparePartsService.GetAll());
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

            return View("InfoPage");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            ViewData["Message"] = id.ToString();
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

            return View("InfoPage");
        }
    }
}
