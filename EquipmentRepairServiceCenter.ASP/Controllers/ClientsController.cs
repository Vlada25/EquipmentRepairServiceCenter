using EquipmentRepairServiceCenter.DTO.Client;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientsService _clientsService;
        private static int _rowsCount = 0;
        private static bool isSurnameAscending = true;
        private static bool isNameAscending = true;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _rowsCount = 20;
            var clients = await _clientsService.Get(_rowsCount, $"Clients{_rowsCount}");

            return View(clients);
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            var clients = await _clientsService.Get(_rowsCount, $"Clients{_rowsCount}");

            return View("GetAll", clients);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            var clients = await _clientsService.Get(_rowsCount, $"Clients{_rowsCount}");

            switch (sortedFieldNumber)
            {
                case 1:
                    if (isSurnameAscending)
                    {
                        isSurnameAscending = !isSurnameAscending;
                        return View("GetAll", clients.OrderBy(c => c.Surname).ToList());
                    }
                    else
                    {
                        isSurnameAscending = !isSurnameAscending;
                        return View("GetAll", clients.OrderByDescending(c => c.Surname).ToList());
                    }
                case 2:
                    if (isNameAscending)
                    {
                        isNameAscending = !isNameAscending;
                        return View("GetAll", clients.OrderBy(c => c.Name).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return View("GetAll", clients.OrderByDescending(c => c.Name).ToList());
                    }
                default:
                    return View("GetAll", clients);
            }
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
