using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        private static int _rowsCount = 0;
        private static int _cacheNumber = 0;
        private static bool isNameAscending = true;
        private static bool isEmailAscending = true;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _rowsCount = 20;

            return Ok(await _usersService.Get(_rowsCount, $"Users{_rowsCount}-{_cacheNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;

            return Ok(await _usersService.Get(_rowsCount, $"Users{_rowsCount}-{_cacheNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> Get(int sortedFieldNumber)
        {
            var users = await _usersService.Get(_rowsCount, $"Users{_rowsCount}-{_cacheNumber}");

            switch (sortedFieldNumber)
            {
                case 1:
                    if (isNameAscending)
                    {
                        isNameAscending = !isNameAscending;
                        return Ok(users.OrderBy(c => c.UserName).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return Ok(users.OrderByDescending(c => c.UserName).ToList());
                    }
                case 2:
                    if (isEmailAscending)
                    {
                        isEmailAscending = !isEmailAscending;
                        return Ok(users.OrderBy(c => c.Email).ToList());
                    }
                    else
                    {
                        isEmailAscending = !isEmailAscending;
                        return Ok(users.OrderByDescending(c => c.Email).ToList());
                    }
                default:
                    return Ok(users);
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isExists = await _usersService.DeleteAsync(id);

            if (!isExists)
            {
                return NotFound();
            }

            _cacheNumber++;

            return NoContent();
        }
    }
}
