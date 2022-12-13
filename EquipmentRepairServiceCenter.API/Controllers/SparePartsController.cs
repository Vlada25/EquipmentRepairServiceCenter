using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.DTO.SparePart;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.API.Controllers
{
    public class SparePartsController : ControllerBase
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
            return Ok(await _sparePartsService.Get(_rowsCount, $"SpareParts{_rowsCount}-{_cacheNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            return Ok(await _sparePartsService.Get(_rowsCount, $"SpareParts{_rowsCount}-{_cacheNumber}"));
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
                        return Ok(spareParts.OrderBy(c => c.Name).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return Ok(spareParts.OrderByDescending(c => c.Name).ToList());
                    }
                case 2:
                    if (isPriceAscending)
                    {
                        isPriceAscending = !isPriceAscending;
                        return Ok(spareParts.OrderBy(c => c.Price).ToList());
                    }
                    else
                    {
                        isPriceAscending = !isPriceAscending;
                        return Ok(spareParts.OrderByDescending(c => c.Price).ToList());
                    }
                case 3:
                    if (isEqTypeAscending)
                    {
                        isEqTypeAscending = !isEqTypeAscending;
                        return Ok(spareParts.OrderBy(c => c.EquipmentType).ToList());
                    }
                    else
                    {
                        isEqTypeAscending = !isEqTypeAscending;
                        return Ok(spareParts.OrderByDescending(c => c.EquipmentType).ToList());
                    }
                default:
                    return Ok(spareParts);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(SparePartForCreationDto sparePartForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sparePartsService.Create(sparePartForCreation);

            _cacheNumber++;

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(SparePartForUpdateDto sparePartForUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isExists = await _sparePartsService.Update(sparePartForUpdate);

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
            bool isExists = await _sparePartsService.Delete(id);

            if (!isExists)
            {
                return NotFound();
            }

            _cacheNumber++;

            return NoContent();
        }
    }
}
