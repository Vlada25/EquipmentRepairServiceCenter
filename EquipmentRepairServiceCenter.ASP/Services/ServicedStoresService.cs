using AutoMapper;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.ServicedStore;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;

namespace EquipmentRepairServiceCenter.ASP.Services
{
    public class ServicedStoresService : IServicedStoresService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ServicedStoresService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ServicedStore> Create(ServicedStoreForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<ServicedStore>(entityForCreation);
            entity.Id = Guid.NewGuid();

            await _repositoryManager.ServicedStoresRepository.Create(entity);
            await _repositoryManager.SaveAsync();

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repositoryManager.ServicedStoresRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.ServicedStoresRepository.Delete(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<ServicedStore>> Get(int rowsCount, string cacheKey) =>
            await _repositoryManager.ServicedStoresRepository.Get(rowsCount, cacheKey);

        public async Task<IEnumerable<ServicedStore>> GetAll() =>
            await _repositoryManager.ServicedStoresRepository.GetAll(false);

        public async Task<ServicedStore> GetById(Guid id) =>
            await _repositoryManager.ServicedStoresRepository.GetById(id, false);

        public async Task<ServicedStore> GetByNameAndAddress(string name, string address) =>
            await _repositoryManager.ServicedStoresRepository.GetByNameAndAddress(name, address);

        public async Task<bool> Update(ServicedStoreForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.ServicedStoresRepository.GetById(entityForUpdate.Id, trackChanges: true);

            if (entity == null)
            {
                return false;
            }

            _mapper.Map(entityForUpdate, entity);

            _repositoryManager.ServicedStoresRepository.Update(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }
    }
}
