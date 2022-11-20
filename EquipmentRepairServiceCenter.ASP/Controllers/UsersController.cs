using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        private static int _rowsCount = 0;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _rowsCount = 20;
            return View(await _usersService.Get(_rowsCount, $"Users{_rowsCount}"));
        }

        [HttpGet]
        public async Task<IActionResult> GetMore()
        {
            _rowsCount += 20;
            return View("GetAll", await _usersService.Get(_rowsCount, $"Users{_rowsCount}"));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            ViewData["Message"] = id.ToString();
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

            return View("InfoPage");
        }
    }
}
