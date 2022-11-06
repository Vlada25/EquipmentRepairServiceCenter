using AutoMapper;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.RepairingModel;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;

namespace EquipmentRepairServiceCenter.ASP.Services
{
    public class RepairingModelsService : IRepairingModelsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public RepairingModelsService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<RepairingModelDto> Create(RepairingModelForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<RepairingModel>(entityForCreation);

            await _repositoryManager.RepairingModelsRepository.Create(entity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<RepairingModelDto>(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repositoryManager.RepairingModelsRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.RepairingModelsRepository.Delete(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<RepairingModelDto>> GetAll()
        {
            var entities = await _repositoryManager.RepairingModelsRepository.GetAll(false);

            return _mapper.Map<IEnumerable<RepairingModelDto>>(entities);
        }


        public async Task<RepairingModelDto> GetById(Guid id)
        {
            var entity = await _repositoryManager.RepairingModelsRepository.GetById(id, false);

            return _mapper.Map<RepairingModelDto>(entity);
        }


        public async Task<bool> Update(RepairingModelForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.RepairingModelsRepository.GetById(entityForUpdate.Id, trackChanges: true);

            if (entity == null)
            {
                return false;
            }

            _mapper.Map(entityForUpdate, entity);

            _repositoryManager.RepairingModelsRepository.Update(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }
    }
}
