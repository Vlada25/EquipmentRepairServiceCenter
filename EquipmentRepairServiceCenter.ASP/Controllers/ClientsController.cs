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
    }
}
