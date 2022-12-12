using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
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
            return View(await _usersService.Get(_rowsCount, $"Users{_rowsCount}-{_cacheNumber}"));
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            return View("GetAll", await _usersService.Get(_rowsCount, $"Users{_rowsCount}-{_cacheNumber}"));
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
                        return View("GetAll", users.OrderBy(c => c.UserName).ToList());
                    }
                    else
                    {
                        isNameAscending = !isNameAscending;
                        return View("GetAll", users.OrderByDescending(c => c.UserName).ToList());
                    }
                case 2:
                    if (isEmailAscending)
                    {
                        isEmailAscending = !isEmailAscending;
                        return View("GetAll", users.OrderBy(c => c.Email).ToList());
                    }
                    else
                    {
                        isEmailAscending = !isEmailAscending;
                        return View("GetAll", users.OrderByDescending(c => c.Email).ToList());
                    }
                default:
                    return View("GetAll", users);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _usersService.GetByIdAsync(id);
            ViewData["Message"] = $"{entity.UserName}";
            Response.Cookies.Append("user_id", id.ToString());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            Request.Cookies.TryGetValue("user_id", out string id);

            bool isExists = await _usersService.DeleteAsync(Guid.Parse(id));

            if (!isExists)
            {
                return View();
            }

            _cacheNumber++;

            return View("InfoPage");
        }
    }
}
