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

namespace EquipmentRepairServiceCenter.API.Controllers
{
    //[Authorize]
    public class RepairingModelsController : ControllerBase
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

            return Ok(repairingModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _rowsCount = 20;
            var repairingModels = await _repairingModelsService.Get(_rowsCount, $"RepairingModels{_rowsCount}-{_cacheNumber}");

            return Ok(repairingModels);
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            var repairingModels = await _repairingModelsService.Get(_rowsCount, $"RepairingModels{_rowsCount}-{_cacheNumber}");

            return Ok(repairingModels);
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
                        return Ok(repairingModels.OrderBy(c => c.Name).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return Ok(repairingModels.OrderByDescending(c => c.Name).ToList());
                    }
                case 2:
                    if (isManufacturerAscending)
                    {
                        isManufacturerAscending = !isManufacturerAscending;
                        return Ok(repairingModels.OrderBy(c => c.Manufacturer).ToList());
                    }
                    else
                    {
                        isManufacturerAscending = !isManufacturerAscending;
                        return Ok(repairingModels.OrderByDescending(c => c.Manufacturer).ToList());
                    }
                default:
                    return Ok(repairingModels);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(RepairingModelCreatedViewModel repairingModelCreated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(RepairingModelForUpdateDto repairingModelUpdated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isExists = await _repairingModelsService.Update(repairingModelUpdated);

            if (!isExists)
            {
                return NotFound();
            }

            _cacheNumber++;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isExists = await _repairingModelsService.Delete(id);

            if (!isExists)
            {
                return NotFound();
            }

            _cacheNumber++;

            return NoContent();
        }
    }
}
