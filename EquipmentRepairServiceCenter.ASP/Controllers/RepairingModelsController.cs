using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.Domain;
using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.DTO.RepairingModel;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    [Authorize]
    public class RepairingModelsController : Controller
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public RepairingModelsController(IFlurlClientFactory flurlClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _flurlClient = flurlClientFactory.Get("https://localhost:7017/api/repairingModels/");
            _contextAccessor = httpContextAccessor;

            var token = _contextAccessor.HttpContext.Request.Cookies["X-Access-Token"];

            if (token != null)
            {
                _flurlClient.WithOAuthBearerToken(token);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return View(await _flurlClient.Request($"/{id}").GetJsonAsync<RepairingModelDto>());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return View(await _flurlClient.Request().GetJsonAsync<List<RepairingModelDto>>());
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            return View("GetAll", await _flurlClient.Request().GetJsonAsync<List<RepairingModelDto>>());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            return View("GetAll", await _flurlClient.Request($"sort?sortedFieldNumber={sortedFieldNumber}").GetJsonAsync<List<RepairingModelDto>>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<string> eqTypes = new List<string>();

            foreach (int i in Enum.GetValues(typeof(EquipmentType)))
                eqTypes.Add(EnumExtensions.GetDisplayName((EquipmentType)Enum.GetValues(typeof(EquipmentType)).GetValue(i)));

            return View(new RepairingModelCreatedViewModel
            {
                EquipmentTypes = eqTypes,
                Manufacturers = DbInitializer.Manufacturers.ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(RepairingModelCreatedViewModel repairingModelCreated)
        {
            if (!ModelState.IsValid)
            {
                List<string> eqTypes = new List<string>();

                foreach (int i in Enum.GetValues(typeof(EquipmentType)))
                    eqTypes.Add(EnumExtensions.GetDisplayName((EquipmentType)Enum.GetValues(typeof(EquipmentType)).GetValue(i)));

                return View(new RepairingModelCreatedViewModel
                {
                    EquipmentTypes = eqTypes,
                    Manufacturers = DbInitializer.Manufacturers.ToList()
                });
            }

            await _flurlClient.Request().PostJsonAsync(repairingModelCreated);

            return View("InfoPage");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var repairingModel = await _flurlClient.Request($"/{id}").GetJsonAsync<RepairingModelDto>();

            return View(new RepairingModelForUpdateDto
            {
                Id = id,
                Specifications = repairingModel.Specifications,
                ParticularQualities = repairingModel.ParticularQualities,
                PhotoUrl = repairingModel.PhotoUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RepairingModelForUpdateDto repairingModelUpdated)
        {
            if (!ModelState.IsValid)
            {
                var repairingModel = await _flurlClient.Request($"/{repairingModelUpdated.Id}").GetJsonAsync<RepairingModelDto>();

                return View(new RepairingModelForUpdateDto
                {
                    Id = repairingModelUpdated.Id,
                    Specifications = repairingModel.Specifications,
                    ParticularQualities = repairingModel.ParticularQualities,
                    PhotoUrl = repairingModel.PhotoUrl
                });
            }

            var result = await _flurlClient.Request().PutJsonAsync(repairingModelUpdated);

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
            Response.Cookies.Append("repairingModel_id", id.ToString());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            Request.Cookies.TryGetValue("repairingModel_id", out string id);

            var result = await _flurlClient.Request($"/{id}").DeleteAsync();

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
            {
                return View();
            }

            return View("InfoPage");
        }
    }
}
