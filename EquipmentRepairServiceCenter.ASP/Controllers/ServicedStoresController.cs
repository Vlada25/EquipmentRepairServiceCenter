using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.DTO.RepairingModel;
using EquipmentRepairServiceCenter.DTO.ServicedStore;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class ServicedStoresController : Controller
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
            return View(await _servicedStoresService.Get(_rowsCount, $"ServicedStores{_rowsCount}-{_cacheNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            return View("GetAll", await _servicedStoresService.Get(_rowsCount, $"ServicedStores{_rowsCount}-{_cacheNumber}"));
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
                        return View("GetAll", servicedStores.OrderBy(c => c.Name).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return View("GetAll", servicedStores.OrderByDescending(c => c.Name).ToList());
                    }
                case 2:
                    if (isAddressAscending)
                    {
                        isAddressAscending = !isAddressAscending;
                        return View("GetAll", servicedStores.OrderBy(c => c.Address).ToList());
                    }
                    else
                    {
                        isAddressAscending = !isAddressAscending;
                        return View("GetAll", servicedStores.OrderByDescending(c => c.Address).ToList());
                    }
                default:
                    return View("GetAll", servicedStores);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicedStoreForCreationDto servicedStore)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _servicedStoresService.Create(servicedStore);

            _cacheNumber++;

            return View("InfoPage");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var servicedStore = await _servicedStoresService.GetById(id);

            return View(new ServicedStoreForUpdateDto
            {
                Id = id,
                Address = servicedStore.Address,
                PhoneNumber = servicedStore.PhoneNumber,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(ServicedStoreForUpdateDto servicedStoreUpdated)
        {
            if (!ModelState.IsValid)
            {
                var servicedStore = await _servicedStoresService.GetById(servicedStoreUpdated.Id);

                return View(new ServicedStoreForUpdateDto
                {
                    Id = servicedStoreUpdated.Id,
                    Address = servicedStore.Address,
                    PhoneNumber = servicedStore.PhoneNumber,
                });
            }

            bool isExists = await _servicedStoresService.Update(servicedStoreUpdated);

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
            var entity = await _servicedStoresService.GetById(id);
            ViewData["Message"] = $"{entity.Name}";
            Response.Cookies.Append("store_id", id.ToString());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            Request.Cookies.TryGetValue("store_id", out string id);

            bool isExists = await _servicedStoresService.Delete(Guid.Parse(id));

            if (!isExists)
            {
                return View();
            }

            _cacheNumber++;

            return View("InfoPage");
        }
    }
}
