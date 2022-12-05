using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.DTO.UsedSparePart;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class UsedSparePartsController : ControllerBase
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
            return Ok(await _usedSparePartsService.Get(_rowsCount, $"UsedSpareParts{_rowsCount}-{_cacheNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            return Ok(await _usedSparePartsService.Get(_rowsCount, $"UsedSpareParts{_rowsCount}-{_cacheNumber}"));
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
                        return Ok(usedSpareParts.OrderBy(c => c.SparePart.Name).ToList());
                    }
                    else
                    {
                        isSparePartNameAscending = !isSparePartNameAscending;
                        return Ok(usedSpareParts.OrderByDescending(c => c.SparePart.Name).ToList());
                    }
                case 2:
                    if (isFaultNameAscending)
                    {
                        isFaultNameAscending = !isFaultNameAscending;
                        return Ok(usedSpareParts.OrderBy(c => c.Fault.Name).ToList());
                    }
                    else
                    {
                        isFaultNameAscending = !isFaultNameAscending;
                        return Ok(usedSpareParts.OrderByDescending(c => c.Fault.Name).ToList());
                    }
                default:
                    return Ok(usedSpareParts);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Create(UsedSparePartCreatedViewModel usedSparePartCreated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _usedSparePartsService.Create(new UsedSparePartForCreationDto
            {
                FaultId = Guid.Parse(usedSparePartCreated.Fault.Split(';')[0]),
                SparePartId = Guid.Parse(usedSparePartCreated.SparePart.Split(';')[0]),
            });

            _cacheNumber++;

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isExists = await _usedSparePartsService.Delete(id);

            if (!isExists)
            {
                return NotFound();
            }

            _cacheNumber++;

            return NoContent();
        }
    }
}
