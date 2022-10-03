using AutoMapper;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.UsedSparePart;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;

namespace EquipmentRepairServiceCenter.ASP.Services
{
    public class UsedSparePartsService : IUsedSparePartsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UsedSparePartsService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<UsedSparePart> Create(UsedSparePartForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<UsedSparePart>(entityForCreation);

            await _repositoryManager.UsedSparePartsRepository.Create(entity);
            await _repositoryManager.SaveAsync();

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repositoryManager.UsedSparePartsRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.UsedSparePartsRepository.Delete(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<UsedSparePart>> GetAll() =>
            await _repositoryManager.UsedSparePartsRepository.GetAll(false);

        public async Task<UsedSparePart> GetById(Guid id) =>
            await _repositoryManager.UsedSparePartsRepository.GetById(id, false);
    }
}
