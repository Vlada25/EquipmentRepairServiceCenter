using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.Domain.Models.User;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpContext _httpContext;
        private readonly UserManager<User> _userManager;
        private readonly IEmployeesService _employeesService;
        private readonly IClientsService _clientsService;

        public HomeController(IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager,
            IEmployeesService employeesService,
            IClientsService clientsService)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _userManager = userManager;
            _employeesService = employeesService;
            _clientsService = clientsService;
        }

        // TODO: attribute authorize

        //[Authorize]
        public async Task<IActionResult> Index()
        {
            var userName = _httpContext.User.Claims
                .Where(claim => claim.Type.Equals(ClaimTypes.Name))
                .Select(claim => claim.Value).SingleOrDefault();

            var user = await _userManager.FindByNameAsync(userName);
            var userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles.Contains("Employee"))
            {
                var employee = await _employeesService.GetByUserId(Guid.Parse(user.Id));

                return View(new ExpandedUserViewModel
                {
                    UserName = userName,
                    Email = user.Email,
                    Surname = employee.Surname,
                    Name = employee.Name,
                    MiddleName = employee.MiddleName,
                    Role = "Employee"
                });
            }

            if (userRoles.Contains("Admin"))
            {
                return View(new ExpandedUserViewModel
                {
                    UserName = userName,
                    Email = user.Email,
                    Surname = "Leonenko",
                    Name = "Vladislava",
                    MiddleName = "Urievna",
                    Role = "Admin"
                });
            }

            var client = await _clientsService.GetByUserId(Guid.Parse(user.Id));

            return View(new ExpandedUserViewModel
            {
                UserName = userName,
                Email = user.Email,
                Surname = client.Surname,
                Name = client.Name,
                MiddleName = client.MiddleName,
                Role = "Client"
            });
        }

        public IActionResult StartPage()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        public IActionResult AdminsPage()
        {
            return View();
        }
    }
}
