using AutoMapper;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.Fault;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;

namespace EquipmentRepairServiceCenter.ASP.Services
{
    public class FaultsService : IFaultsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public FaultsService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Fault> Create(FaultForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Fault>(entityForCreation);

            await _repositoryManager.FaultsRepository.Create(entity);
            await _repositoryManager.SaveAsync();

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repositoryManager.FaultsRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.FaultsRepository.Delete(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<Fault>> GetAll() =>
            await _repositoryManager.FaultsRepository.GetAll(false);

        public async Task<Fault> GetById(Guid id) =>
            await _repositoryManager.FaultsRepository.GetById(id, false);

        public async Task<bool> Update(FaultForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.FaultsRepository.GetById(entityForUpdate.Id, trackChanges: true);

            if (entity == null)
            {
                return false;
            }

            _mapper.Map(entityForUpdate, entity);

            _repositoryManager.FaultsRepository.Update(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }
    }
}
