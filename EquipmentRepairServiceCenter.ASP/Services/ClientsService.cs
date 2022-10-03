using AutoMapper;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.DTO.Client;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;

namespace EquipmentRepairServiceCenter.ASP.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ClientsService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Client> Create(ClientForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Client>(entityForCreation);

            await _repositoryManager.ClientsRepository.Create(entity);
            await _repositoryManager.SaveAsync();

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repositoryManager.ClientsRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.ClientsRepository.Delete(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<Client>> GetAll() =>
            await _repositoryManager.ClientsRepository.GetAll(false);

        public async Task<Client> GetById(Guid id) =>
            await _repositoryManager.ClientsRepository.GetById(id, false);

        public async Task<bool> Update(ClientForUpdateDto entityForUpdate)
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
