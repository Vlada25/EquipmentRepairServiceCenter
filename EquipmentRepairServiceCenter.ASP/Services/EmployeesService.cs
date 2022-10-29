using AutoMapper;
using EquipmentRepairServiceCenter.Domain;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.Domain.Models.User;
using EquipmentRepairServiceCenter.DTO.Employee;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepairServiceCenter.ASP.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public EmployeesService(IRepositoryManager repositoryManager,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<EmployeeDto> Create(EmployeeForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Employee>(entityForCreation);

            await _repositoryManager.EmployeesRepository.Create(entity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<EmployeeDto>(entity);
        }

        public async Task CreateByUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var servicedStores = await _repositoryManager.ServicedStoresRepository.GetAll(false);

            DbInitializer.InitEmployees(users, servicedStores.ToList());

            foreach (Employee entity in DbInitializer.Employees)
            {
                await _repositoryManager.EmployeesRepository.Create(entity);
            }

            await _repositoryManager.SaveAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repositoryManager.EmployeesRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.EmployeesRepository.Delete(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var entities = await _repositoryManager.EmployeesRepository.GetAll(false);

            return _mapper.Map<IEnumerable<EmployeeDto>>(entities);
        }
            

        public async Task<EmployeeDto> GetById(Guid id)
        {
            var entity = await _repositoryManager.EmployeesRepository.GetById(id, false);

            return _mapper.Map<EmployeeDto>(entity);
        }
            

        public async Task<bool> Update(EmployeeForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.OrdersRepository.GetById(entityForUpdate.Id, trackChanges: true);

            if (entity == null)
            {
                return false;
            }

            _mapper.Map(entityForUpdate, entity);

            _repositoryManager.OrdersRepository.Update(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }
    }
}
