using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.DTO.RepairingModel;
using EquipmentRepairServiceCenter.DTO.ServicedStore;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class ServicedStoresController : ControllerBase
    {
        private readonly IServicedStoresService _servicedStoresService;

        private static int _rowsCount = 0;
        private static int _cacheNumber = 0;
        private static bool isNameAscending = true;
        private static bool isAddressAscending = true;

        public ServicedStoresController(IServicedStoresService servicedStoresService)
        {
            _servicedStoresService = servicedStoresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _rowsCount = 20;

            return Ok(await _servicedStoresService.Get(_rowsCount, $"ServicedStores{_rowsCount}-{_cacheNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;

            return Ok(await _servicedStoresService.Get(_rowsCount, $"ServicedStores{_rowsCount}-{_cacheNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            var servicedStores = await _servicedStoresService.Get(_rowsCount, $"ServicedStores{_rowsCount}-{_cacheNumber}");

            switch (sortedFieldNumber)
            {
                case 1:
                    if (isNameAscending)
                    {
                        isNameAscending = !isNameAscending;
                        return Ok(servicedStores.OrderBy(c => c.Name).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return Ok(servicedStores.OrderByDescending(c => c.Name).ToList());
                    }
                case 2:
                    if (isAddressAscending)
                    {
                        isAddressAscending = !isAddressAscending;
                        return Ok(servicedStores.OrderBy(c => c.Address).ToList());
                    }
                    else
                    {
                        isAddressAscending = !isAddressAscending;
                        return Ok(servicedStores.OrderByDescending(c => c.Address).ToList());
                    }
                default:
                    return Ok(servicedStores);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicedStoreForCreationDto servicedStore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _servicedStoresService.Create(servicedStore);

            _cacheNumber++;

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Update(ServicedStoreForUpdateDto servicedStoreUpdated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isExists = await _servicedStoresService.Update(servicedStoreUpdated);

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
            bool isExists = await _servicedStoresService.Delete(id);

            if (!isExists)
            {
                return NotFound();
            }

            _cacheNumber++;

            return NoContent();
        }
    }
}
