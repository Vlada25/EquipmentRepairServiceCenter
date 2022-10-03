using AutoMapper;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.DTO.Employee;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;

namespace EquipmentRepairServiceCenter.ASP.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public EmployeesService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Create(EmployeeForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Employee>(entityForCreation);

            await _repositoryManager.EmployeesRepository.Create(entity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<EmployeeDto>(entity);
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
