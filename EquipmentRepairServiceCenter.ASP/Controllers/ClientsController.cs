using EquipmentRepairServiceCenter.DTO.Client;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientsService.GetAll();
            return View(clients);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var client = await _clientsService.GetById(id);

            return View(new ClientForUpdateDto
            {
                Id = id,
                Surname = client.Surname,
                Name = client.Name,
                MiddleName = client.MiddleName,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(ClientForUpdateDto clientForUpdate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isExists = await _clientsService.Update(clientForUpdate);

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
            Response.Cookies.Append("client_id", id.ToString());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            Request.Cookies.TryGetValue("client_id", out string id);

            bool isExists = await _clientsService.Delete(Guid.Parse(id));

            if (!isExists)
            {
                return View();
            }

            return View("InfoPage");
        }
    }
}
