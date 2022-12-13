using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.Fault;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    //[Authorize]
    public class FaultsController : Controller
    {
        private readonly IFaultsService _faultsService;
        private readonly IRepairingModelsService _repairingModelsService;
        private readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _contextAccessor;

        private static int _rowsCount;
        private static int _cacheNumber = 0;
        private static bool isRepModelAscending = true;
        private static bool isNameAscending = true;
        private static bool isPriceAscending = true;

        public FaultsController(IFaultsService faultsService,
            IRepairingModelsService repairingModelsService,
            IFlurlClientFactory flurlClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _faultsService = faultsService;
            _repairingModelsService = repairingModelsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _rowsCount = 20;
            ViewData["f_repairingModelName"] = Request.Cookies["f_repairingModelName"];
            ViewData["f_name"] = Request.Cookies["f_name"];
            ViewData["f_repairingMethods"] = Request.Cookies["f_repairingMethods"];

            var faults = await _faultsService.Get(_rowsCount, $"Faults{_rowsCount}-{_cacheNumber}");

            return View(faults);
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            ViewData["f_repairingModelName"] = Request.Cookies["f_repairingModelName"];
            ViewData["f_name"] = Request.Cookies["f_name"];
            ViewData["f_repairingMethods"] = Request.Cookies["f_repairingMethods"];

            var faults = await _faultsService.Get(_rowsCount, $"Faults{_rowsCount}-{_cacheNumber}");

            return View("GetAll", faults);
        }

        [HttpGet]
        public async Task<IActionResult> ClearCookie()
        {
            _rowsCount = 20;

            Response.Cookies.Delete("f_repairingModelName");
            Response.Cookies.Delete("f_name");
            Response.Cookies.Delete("f_repairingMethods");

            var faults = await _faultsService.Get(_rowsCount, $"Faults{_rowsCount}-{_cacheNumber}");

            return View("GetAll", faults);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            var faults = await _faultsService.Get(_rowsCount, $"Faults{_rowsCount}-{_cacheNumber}");

            switch (sortedFieldNumber)
            {
                case 1:
                    if (isNameAscending)
                    {
                        isNameAscending = !isNameAscending;
                        return View("GetAll", faults.OrderBy(c => c.Name).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return View("GetAll", faults.OrderByDescending(c => c.Name).ToList());
                    }
                case 2:
                    if (isRepModelAscending)
                    {
                        isRepModelAscending = !isRepModelAscending;
                        return View("GetAll", faults.OrderBy(c => c.RepairingModel.Name).ToList());
                    }
                    else
                    {
                        isRepModelAscending = !isRepModelAscending;
                        return View("GetAll", faults.OrderByDescending(c => c.RepairingModel.Name).ToList());
                    }
                case 3:
                    if (isPriceAscending)
                    {
                        isPriceAscending = !isPriceAscending;
                        return View("GetAll", faults.OrderBy(c => c.Price).ToList());
                    }
                    else
                    {
                        isPriceAscending = !isPriceAscending;
                        return View("GetAll", faults.OrderByDescending(c => c.Price).ToList());
                    }
                default:
                    return View("GetAll", faults);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByProps(string f_repairingModelName, string f_name, string f_repairingMethods)
        {
            var faults = await _faultsService.GetAll();

            if (f_repairingModelName is not null)
                Response.Cookies.Append("f_repairingModelName", f_repairingModelName);
            if (f_name is not null)
                Response.Cookies.Append("f_name", f_name);
            if (f_repairingMethods is not null)
                Response.Cookies.Append("f_repairingMethods", f_repairingMethods);

            ViewData["f_repairingModelName"] = Request.Cookies["f_repairingModelName"];
            ViewData["f_name"] = Request.Cookies["f_name"];
            ViewData["f_repairingMethods"] = Request.Cookies["f_repairingMethods"];

            if (f_repairingModelName is null) f_repairingModelName = Guid.NewGuid().ToString();
            if (f_name is null) f_name = Guid.NewGuid().ToString();
            if (f_repairingMethods is null) f_repairingMethods = Guid.NewGuid().ToString();

            return View("GetAll", faults.Where(f =>
                f.RepairingModel.Name.Contains(f_repairingModelName, StringComparison.OrdinalIgnoreCase) ||
                f.Name.Contains(f_name, StringComparison.OrdinalIgnoreCase) ||
                f.RepairingMethods.Contains(f_repairingMethods, StringComparison.OrdinalIgnoreCase))
                .ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var repModels = await _repairingModelsService.GetAll();

            return View(new FaultCreatedViewModel
            {
                RepairingModels = repModels.ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(FaultCreatedViewModel fault)
        {
            if (!ModelState.IsValid)
            {
                var repModels = await _repairingModelsService.GetAll();

                return View(new FaultCreatedViewModel
                {
                    RepairingModels = repModels.ToList()
                });
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

            return View("InfoPage");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var fault = await _faultsService.GetById(id);

            return View(new FaultForUpdateDto
            {
                Id = id,
                RepairingMethods = fault.RepairingMethods,
                Price = fault.Price
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(FaultForUpdateDto faultUpdated)
        {
            if (!ModelState.IsValid)
            {
                var fault = await _faultsService.GetById(faultUpdated.Id);

                return View(new FaultForUpdateDto
                {
                    Id = faultUpdated.Id,
                    RepairingMethods = fault.RepairingMethods,
                    Price = fault.Price
                });
            }

            bool isExists = await _faultsService.Update(faultUpdated);

            if (!isExists)
            {
                return View();
            }

            _cacheNumber++;

            return View("InfoPage");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            ViewData["Message"] = id.ToString();
            Response.Cookies.Append("fault_id", id.ToString());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            Request.Cookies.TryGetValue("fault_id", out string id);

            bool isExists = await _faultsService.Delete(Guid.Parse(id));

            if (!isExists)
            {
                return View();
            }

            _cacheNumber++;

            return View("InfoPage");
        }
    }
}
