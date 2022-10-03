using AutoMapper;
using EquipmentRepairServiceCenter.Domain;
using EquipmentRepairServiceCenter.Domain.Models.User;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;

        private readonly IClientsService _clientsService;
        private readonly IEmployeesService _employeesService;
        private readonly IOrdersService _ordersService;

        public AccountsController(IAuthenticationManager authManager,
            UserManager<User> userManager,
            IMapper mapper,
            IOrdersService ordersService,
            IClientsService clientsService,
            IEmployeesService employeesService)
        {
            _authManager = authManager;
            _userManager = userManager;
            _mapper = mapper;
            _ordersService = ordersService;
            _clientsService = clientsService;
            _employeesService = employeesService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (loginUser == null)
            {
                ViewData["Message"] = "LoginUser object sent from client is null.";
                return View();
            }

            if (!await _authManager.ValidateUser(loginUser))
            {
                ViewData["Message"] = "Authentication failed. Wrong user name or password.";
                return View();
            }

            string token = await _authManager.CreateToken();

            Response.Cookies.Append("X-Access-Token", token, new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(5)
            });

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            var user = _mapper.Map<User>(registerUser);

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                ViewData["Message"] = ModelState;
                return View();
            }

            return RedirectToRoute(new { controller = "Accounts", action = "Login" });
        }

        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> CreateFakeUsers()
        {
            await RegisterFakeUser(new RegisterUser
            {
                Surname = "Leonenko",
                Name = "Vladislava",
                MiddleName = "Jurievna",
                UserName = "aladka03",
                Email = "aladka03@gmail.com",
                Password = "admin1111",
                ConfirmPassword = "admin1111"
            }, 1);

            DbInitializer.InitUsers(20);
            foreach (RegisterUser registerUser in DbInitializer.RegisterUsers)
            {
                await RegisterFakeUser(registerUser, 2);
            }
            await _employeesService.CreateByUsers();

            DbInitializer.InitUsers(50);
            foreach (RegisterUser registerUser in DbInitializer.RegisterUsers)
            {
                await RegisterFakeUser(registerUser, 0);
            }
            await _clientsService.CreateByUsers();

            await _ordersService.CreateMany();

            return Ok();
        }

        private async Task RegisterFakeUser(RegisterUser registerUser, int role)
        {
            var user = _mapper.Map<User>(registerUser);

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                throw new Exception(ModelState.ToString());
            }

            if (role == 1)
                await _userManager.AddToRolesAsync(user, new string[] {"Admin"});
            if (role == 2)
                await _userManager.AddToRolesAsync(user, new string[] { "Employee" });
        }
    }
}
