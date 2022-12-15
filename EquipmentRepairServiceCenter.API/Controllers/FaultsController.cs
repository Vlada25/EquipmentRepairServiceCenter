using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.Fault;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EquipmentRepairServiceCenter.API.Controllers
{
    [Authorize]
    [Route("api/faults")]

    public class FaultsController : ControllerBase
    {
        private readonly IFaultsService _faultsService;

        private static int _rowsCount;
        private static int _cacheNumber = 0;
        private static bool isRepModelAscending = true;
        private static bool isNameAscending = true;
        private static bool isPriceAscending = true;

        public FaultsController(IFaultsService faultsService)
        {
            _faultsService = faultsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _rowsCount = 20;

            var faults = await _faultsService.Get(_rowsCount, $"Faults{_rowsCount}-{_cacheNumber}");

            return Ok(faults);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var fault = await _faultsService.GetById(id);

            return Ok(fault);
        }

        [HttpGet("getMore")]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;

            var faults = await _faultsService.Get(_rowsCount, $"Faults{_rowsCount}-{_cacheNumber}");

            return Ok(faults);
        }

        [HttpGet("sort")]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            var faults = await _faultsService.Get(_rowsCount, $"Faults{_rowsCount}-{_cacheNumber}");

            switch (sortedFieldNumber)
            {
                case 1:
                    if (isNameAscending)
                    {
                        isNameAscending = !isNameAscending;
                        return Ok(faults.OrderBy(c => c.Name).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return Ok(faults.OrderByDescending(c => c.Name).ToList());
                    }
                case 2:
                    if (isRepModelAscending)
                    {
                        isRepModelAscending = !isRepModelAscending;
                        return Ok(faults.OrderBy(c => c.RepairingModel.Name).ToList());
                    }
                    else
                    {
                        isRepModelAscending = !isRepModelAscending;
                        return Ok(faults.OrderByDescending(c => c.RepairingModel.Name).ToList());
                    }
                case 3:
                    if (isPriceAscending)
                    {
                        isPriceAscending = !isPriceAscending;
                        return Ok(faults.OrderBy(c => c.Price).ToList());
                    }
                    else
                    {
                        isPriceAscending = !isPriceAscending;
                        return Ok(faults.OrderByDescending(c => c.Price).ToList());
                    }
                default:
                    return Ok(faults);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetAllByProps(string f_repairingModelName, string f_name, string f_repairingMethods)
        {
            var faults = await _faultsService.GetAll();

            f_repairingModelName ??= Guid.NewGuid().ToString();
            f_name ??= Guid.NewGuid().ToString();
            f_repairingMethods ??= Guid.NewGuid().ToString();

            return Ok(faults.Where(f =>
                f.RepairingModel.Name.Contains(f_repairingModelName, StringComparison.OrdinalIgnoreCase) ||
                f.Name.Contains(f_name, StringComparison.OrdinalIgnoreCase) ||
                f.RepairingMethods.Contains(f_repairingMethods, StringComparison.OrdinalIgnoreCase))
                .ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(FaultCreatedViewModel fault)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Guid repModelId = Guid.Parse(fault.RepairingModel.Split(", ")[0]);

            await _faultsService.Create(new FaultForCreationDto
            {
                Name = fault.Name,
                RepairingModelId = repModelId,
                RepairingMethods = fault.RepairingMethods,
                Price = fault.Price
            });

            _cacheNumber++;

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(FaultForUpdateDto faultUpdated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isExists = await _faultsService.Update(faultUpdated);

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
            bool isExists = await _faultsService.Delete(id);

            if (!isExists)
            {
                return NotFound();
            }

            _cacheNumber++;

            return NoContent();
        }
    }
}
