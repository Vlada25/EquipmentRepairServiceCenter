using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.Database;
using EquipmentRepairServiceCenter.Domain.Models.Users;
using EquipmentRepairServiceCenter.Interfaces.Services;
using EquipmentRepairServiceCenter.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EquipmentRepairServiceCenter.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
            });

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
                    b.MigrationsAssembly("EquipmentRepairServiceCenter.Database")));
        }

        public static void ConfigureDbManagers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddHttpContextAccessor();

            services.AddScoped<IClientsService, ClientsService>();
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IFaultsService, FaultsService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IRepairingModelsService, RepairingModelsService>();
            services.AddScoped<IServicedStoresService, ServicedStoresService>();
            services.AddScoped<ISparePartsService, SparePartsService>();
            services.AddScoped<IUsedSparePartsService, UsedSparePartsService>();
            services.AddScoped<IUsersService, UsersService>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
                o.User.RequireUniqueEmail = true;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole),
            builder.Services);
            builder.AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("SECRET");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }
    }
}
