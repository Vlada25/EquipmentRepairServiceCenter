using EquipmentRepairServiceCenter.DTO.Client;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        private static int _rowsCount = 0;
        private static bool isSurnameAscending = true;
        private static bool isNameAscending = true;
        private static int _cacheNumber = 0;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _rowsCount = 20;
            var clients = await _clientsService.Get(_rowsCount, $"Clients{_rowsCount}-{_cacheNumber}");

            return Ok(clients);
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            var clients = await _clientsService.Get(_rowsCount, $"Clients{_rowsCount}-{_cacheNumber}");

            return Ok(clients);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            var clients = await _clientsService.Get(_rowsCount, $"Clients{_rowsCount}-{_cacheNumber}");

            switch (sortedFieldNumber)
            {
                case 1:
                    if (isSurnameAscending)
                    {
                        isSurnameAscending = !isSurnameAscending;
                        return Ok(clients.OrderBy(c => c.Surname).ToList());
                    }
                    else
                    {
                        isSurnameAscending = !isSurnameAscending;
                        return Ok(clients.OrderByDescending(c => c.Surname).ToList());
                    }
                case 2:
                    if (isNameAscending)
                    {
                        isNameAscending = !isNameAscending;
                        return Ok(clients.OrderBy(c => c.Name).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return Ok(clients.OrderByDescending(c => c.Name).ToList());
                    }
                default:
                    return Ok(clients);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClientForUpdateDto clientForUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isExists = await _clientsService.Update(clientForUpdate);

            if (!isExists)
            {
                return NotFound();
            }

            _cacheNumber++;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isExists = await _clientsService.Delete(id);

            if (!isExists)
            {
                return NotFound();
            }

            _cacheNumber++;

            return NoContent();
        }
    }
}
