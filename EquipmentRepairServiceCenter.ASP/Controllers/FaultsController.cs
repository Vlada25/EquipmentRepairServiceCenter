using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.Fault;
using EquipmentRepairServiceCenter.DTO.RepairingModel;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Data;
using System.Net;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    [Authorize]
    public class FaultsController : Controller
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IFlurlClient _flurlClientForRepairingModels;
        private readonly IHttpContextAccessor _contextAccessor;

        public FaultsController(IFlurlClientFactory flurlClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _flurlClient = flurlClientFactory.Get("https://localhost:7017/api/faults/");
            _flurlClientForRepairingModels = flurlClientFactory.Get("https://localhost:7017/api/repairingModels/");
            _contextAccessor = httpContextAccessor;

            var token = _contextAccessor.HttpContext.Request.Cookies["X-Access-Token"];

            if (token != null)
            {
                _flurlClient.WithOAuthBearerToken(token);
                _flurlClientForRepairingModels.WithOAuthBearerToken(token);
            } 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ViewData["f_repairingModelName"] = Request.Cookies["f_repairingModelName"];
            ViewData["f_name"] = Request.Cookies["f_name"];
            ViewData["f_repairingMethods"] = Request.Cookies["f_repairingMethods"];

            return View(await _flurlClient.Request().GetJsonAsync<List<Fault>>());
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            ViewData["f_repairingModelName"] = Request.Cookies["f_repairingModelName"];
            ViewData["f_name"] = Request.Cookies["f_name"];
            ViewData["f_repairingMethods"] = Request.Cookies["f_repairingMethods"];

            return View("GetAll", await _flurlClient.Request("getMore").GetJsonAsync<List<Fault>>());
        }

        [HttpGet]
        public async Task<IActionResult> ClearCookie()
        {
            Response.Cookies.Delete("f_repairingModelName");
            Response.Cookies.Delete("f_name");
            Response.Cookies.Delete("f_repairingMethods");

            return View("GetAll", await _flurlClient.Request().GetJsonAsync<List<Fault>>());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            return View("GetAll", await _flurlClient.Request($"sort?sortedFieldNumber={sortedFieldNumber}").GetJsonAsync<List<Fault>>());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByProps(string f_repairingModelName, string f_name, string f_repairingMethods)
        {
            if (f_repairingModelName is not null)
                Response.Cookies.Append("f_repairingModelName", f_repairingModelName);
            if (f_name is not null)
                Response.Cookies.Append("f_name", f_name);
            if (f_repairingMethods is not null)
                Response.Cookies.Append("f_repairingMethods", f_repairingMethods);

            ViewData["f_repairingModelName"] = Request.Cookies["f_repairingModelName"];
            ViewData["f_name"] = Request.Cookies["f_name"];
            ViewData["f_repairingMethods"] = Request.Cookies["f_repairingMethods"];

            return View("GetAll", await _flurlClient.Request($"GetAllByProps?f_repairingModelName={f_repairingModelName}&f_name={f_name}&f_repairingMethods={f_repairingMethods}")
                .GetJsonAsync<List<Fault>>());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var repModels = await _flurlClientForRepairingModels.Request().GetJsonAsync<List<RepairingModelDto>>();

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
                var repModels = await _flurlClientForRepairingModels.Request().GetJsonAsync<List<RepairingModelDto>>();

                return View(new FaultCreatedViewModel
                {
                    RepairingModels = repModels.ToList()
                });
            }

            await _flurlClient.Request("Create/").PostJsonAsync(fault);

            return View("InfoPage");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var fault = await _flurlClient.Request($"/{id}").GetJsonAsync<Fault>();

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
                var fault = await _flurlClient.Request($"/{faultUpdated.Id}").GetJsonAsync<Fault>();

                return View(new FaultForUpdateDto
                {
                    Id = faultUpdated.Id,
                    RepairingMethods = fault.RepairingMethods,
                    Price = fault.Price
                });
            }

            var result = await _flurlClient.Request().PutJsonAsync(faultUpdated);

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
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

            var result = await _flurlClient.Request($"/{id}").DeleteAsync();

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
            {
                return View();
            }

            return View("InfoPage");
        }
    }
}
