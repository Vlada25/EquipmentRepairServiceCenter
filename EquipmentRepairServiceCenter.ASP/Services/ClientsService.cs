using AutoMapper;
using EquipmentRepairServiceCenter.Domain;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.Domain.Models.Users;
using EquipmentRepairServiceCenter.DTO.Client;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRepairServiceCenter.ASP.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public ClientsService(IRepositoryManager repositoryManager,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Client> Create(ClientForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Client>(entityForCreation);

            await _repositoryManager.ClientsRepository.Create(entity);
            await _repositoryManager.SaveAsync();

            return entity;
        }

        public async Task CreateByUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            DbInitializer.InitClients(users);

            foreach (Client entity in DbInitializer.Clients)
            {
                await _repositoryManager.ClientsRepository.Create(entity);
            }

            await _repositoryManager.SaveAsync();
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

        public async Task<Client> GetByUserId(Guid userId) =>
            await _repositoryManager.ClientsRepository.GetByUserId(userId, trackChanges: false);

        public async Task<bool> Update(ClientForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.ClientsRepository.GetById(entityForUpdate.Id, trackChanges: true);

            if (entity == null)
            {
                return false;
            }

            _mapper.Map(entityForUpdate, entity);

            _repositoryManager.ClientsRepository.Update(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }
    }
}
