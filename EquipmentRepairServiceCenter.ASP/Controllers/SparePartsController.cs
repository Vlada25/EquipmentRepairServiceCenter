using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.DTO.RepairingModel;
using EquipmentRepairServiceCenter.DTO.SparePart;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    [Authorize]
    public class SparePartsController : Controller
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public SparePartsController(IFlurlClientFactory flurlClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _flurlClient = flurlClientFactory.Get("https://localhost:7017/api/spareParts/");
            _contextAccessor = httpContextAccessor;

            var token = _contextAccessor.HttpContext.Request.Cookies["X-Access-Token"];

            if (token != null)
            {
                _flurlClient.WithOAuthBearerToken(token);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return View(await _flurlClient.Request().GetJsonAsync<List<SparePartDto>>());
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            return View("GetAll", await _flurlClient.Request().GetJsonAsync<List<SparePartDto>>());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            return View("GetAll", await _flurlClient.Request($"sort?sortedFieldNumber={sortedFieldNumber}").GetJsonAsync<List<SparePartDto>>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var eqTypes = new List<string>();

            foreach (int i in Enum.GetValues(typeof(EquipmentType)))
                eqTypes.Add(EnumExtensions.GetDisplayName((EquipmentType)Enum.GetValues(typeof(EquipmentType)).GetValue(i)));

            return View(new SparePartForCreationDto
            {
                EquipmentTypes = eqTypes
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SparePartForCreationDto sparePartForCreation)
        {
            if (!ModelState.IsValid)
            {
                var eqTypes = new List<string>();

                foreach (int i in Enum.GetValues(typeof(EquipmentType)))
                    eqTypes.Add(EnumExtensions.GetDisplayName((EquipmentType)Enum.GetValues(typeof(EquipmentType)).GetValue(i)));

                return View(new SparePartForCreationDto
                {
                    EquipmentTypes = eqTypes
                });
            }

            await _flurlClient.Request().PostJsonAsync(sparePartForCreation);

            return View("InfoPage");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var sparePart = await _flurlClient.Request($"/{id}").GetJsonAsync<SparePartDto>();

            return View(new SparePartForUpdateDto
            {
                Id = id,
                Functions = sparePart.Functions,
                Price = sparePart.Price
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(SparePartForUpdateDto sparePartForUpdate)
        {
            if (!ModelState.IsValid)
            {
                var sparePart = await _flurlClient.Request($"/{sparePartForUpdate}").GetJsonAsync<SparePartDto>();

                return View(new SparePartForUpdateDto
                {
                    Id = sparePartForUpdate.Id,
                    Functions = sparePart.Functions,
                    Price = sparePart.Price
                });
            }

            var result = await _flurlClient.Request().PutJsonAsync(sparePartForUpdate);

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
            Response.Cookies.Append("sparePart_id", id.ToString());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            Request.Cookies.TryGetValue("sparePart_id", out string id);

            var result = await _flurlClient.Request($"/{id}").DeleteAsync();

            if (result.StatusCode == (int)HttpStatusCode.NotFound)
            {
                return View();
            }

            return View("InfoPage");
        }
    }
}
