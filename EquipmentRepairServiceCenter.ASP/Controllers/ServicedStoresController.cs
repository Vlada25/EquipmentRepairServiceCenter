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

        public ServicedStoresController(IServicedStoresService servicedStoresService)
        {
            _servicedStoresService = servicedStoresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _rowsCount = 20;
            return View(await _servicedStoresService.Get(_rowsCount, $"ServicedStores{_rowsCount}"));
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            return View("GetAll", await _servicedStoresService.Get(_rowsCount, $"ServicedStores{_rowsCount}"));
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

            return View("InfoPage");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            ViewData["Message"] = id.ToString();
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

            return View("InfoPage");
        }
    }
}
