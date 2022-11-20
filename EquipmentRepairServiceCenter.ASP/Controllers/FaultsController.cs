using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.Fault;
using EquipmentRepairServiceCenter.Interfaces.Services;
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

        public FaultsController(IFaultsService faultsService,
            IRepairingModelsService repairingModelsService)
        {
            _faultsService = faultsService;
            _repairingModelsService = repairingModelsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var faults = await _faultsService.GetAll();

            return View(faults);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByProps(string repairingModelName, string name, string repairingMethods)
        {
            var faults = await _faultsService.GetAll();

            if (repairingModelName is null) repairingModelName = Guid.NewGuid().ToString();
            if (name is null) name = Guid.NewGuid().ToString();
            if (repairingMethods is null) repairingMethods = Guid.NewGuid().ToString();

            return View("GetAll", faults.Where(f =>
                f.RepairingModel.Name.Contains(repairingModelName, StringComparison.OrdinalIgnoreCase) ||
                f.Name.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                f.RepairingMethods.Contains(repairingMethods, StringComparison.OrdinalIgnoreCase))
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

            return View("InfoPage");
        }

        [HttpGet]
        //[Authorize(Roles = "Employee")]
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
        //[Authorize(Roles = "Employee")]
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

            return View("InfoPage");
        }
    }
}
