using AutoMapper;
using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.ASP.ViewModels;
using EquipmentRepairServiceCenter.Domain;
using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.Domain.Models.Users;
using EquipmentRepairServiceCenter.DTO.Client;
using EquipmentRepairServiceCenter.DTO.Employee;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EquipmentRepairServiceCenter.ASP.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthenticationManager _authManager;

        private readonly IClientsService _clientsService;
        private readonly IEmployeesService _employeesService;
        private readonly IOrdersService _ordersService;
        private readonly IServicedStoresService _servicedStoresService;

        public AccountsController(IAuthenticationManager authManager,
            UserManager<User> userManager,
            IMapper mapper,
            IOrdersService ordersService,
            IClientsService clientsService,
            IEmployeesService employeesService,
            RoleManager<IdentityRole> roleManager,
            IServicedStoresService servicedStoresService)
        {
            _authManager = authManager;
            _userManager = userManager;
            _mapper = mapper;
            _ordersService = ordersService;
            _clientsService = clientsService;
            _employeesService = employeesService;
            _roleManager = roleManager;
            _servicedStoresService = servicedStoresService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (!ModelState.IsValid)
            {
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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

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

            var userFound = await _userManager.FindByNameAsync(registerUser.UserName);

            await _clientsService.Create(new ClientForCreationDto
            {
                Surname = registerUser.Surname,
                Name = registerUser.Name,
                MiddleName = registerUser.MiddleName,
                UserId = Guid.Parse(userFound.Id)
            });

            return RedirectToRoute(new { controller = "Accounts", action = "Login" });
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUser registerUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

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

            return View("InfoPage");
        }

        [HttpGet]
        public IActionResult RegisterClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterClient(RegisterUser registerUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

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

            var userFound = await _userManager.FindByNameAsync(registerUser.UserName);

            await _clientsService.Create(new ClientForCreationDto
            {
                Surname = registerUser.Surname,
                Name = registerUser.Name,
                MiddleName = registerUser.MiddleName,
                UserId = Guid.Parse(userFound.Id)
            });

            return View("InfoPage");
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterEmployee()
        {
            var positions = new List<string>();
            var servicedStores = await _servicedStoresService.GetAll();

            foreach (int i in Enum.GetValues(typeof(Position)))
                positions.Add(EnumExtensions.GetDisplayName((Position)Enum.GetValues(typeof(Position)).GetValue(i)));

            return View(new RegisterEmployeeViewModel
            {
                Positions = positions,
                ServicedStores = servicedStores.ToList()
            });
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterEmployee(RegisterEmployeeViewModel registerUser)
        {
            if (!ModelState.IsValid)
            {
                var ms = ModelState;
                var positions = new List<string>();
                var servicedStores = await _servicedStoresService.GetAll();

                foreach (int i in Enum.GetValues(typeof(Position)))
                    positions.Add(EnumExtensions.GetDisplayName((Position)Enum.GetValues(typeof(Position)).GetValue(i)));

                return View(new RegisterEmployeeViewModel
                {
                    Positions = positions,
                    ServicedStores = servicedStores.ToList()
                });
            }

            var user = _mapper.Map<User>(new RegisterUser
            {
                Name = registerUser.Name,
                Surname = registerUser.Surname,
                MiddleName = registerUser.MiddleName,
                UserName = registerUser.UserName,
                Password = registerUser.Password,
                ConfirmPassword = registerUser.ConfirmPassword,
                Email = registerUser.Email
            });

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

            await _roleManager.RoleExistsAsync("Employee");

            string[] servicedStoreInfo = registerUser.ServicedStore.Split("; ");
            var servicedStore = await _servicedStoresService.GetByNameAndAddress(
                servicedStoreInfo[0], servicedStoreInfo[1]);

            var userFound = await _userManager.FindByNameAsync(registerUser.UserName);

            await _employeesService.Create(new EmployeeForCreationDto
            {
                Surname = registerUser.Surname,
                Name = registerUser.Name,
                MiddleName = registerUser.MiddleName,
                Position = registerUser.Position,
                WorkExperienceInYears = 0,
                ServicedStoreId = servicedStore.Id,
                UserId = Guid.Parse(userFound.Id)
            });

            return View("InfoPage");
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

            DbInitializer.InitUsers(100);
            var r1 = DbInitializer.RegisterUsers;
            foreach (RegisterUser registerUser in DbInitializer.RegisterUsers)
            {
                await RegisterFakeUser(registerUser, 2);
            }
            await _employeesService.CreateByUsers();

            DbInitializer.InitUsers(50);
            var r2 = DbInitializer.RegisterUsers;
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
                await _userManager.AddToRolesAsync(user, new string[] { "Admin" });
            if (role == 2)
                await _userManager.AddToRolesAsync(user, new string[] { "Employee" });
        }
    }
}
