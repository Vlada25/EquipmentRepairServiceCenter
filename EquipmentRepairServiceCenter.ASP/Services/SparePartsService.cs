using AutoMapper;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.SparePart;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;

namespace EquipmentRepairServiceCenter.ASP.Services
{
    public class SparePartsService : ISparePartsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SparePartsService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<SparePartDto> Create(SparePartForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<SparePart>(entityForCreation);

            await _repositoryManager.SparePartsRepository.Create(entity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<SparePartDto>(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repositoryManager.SparePartsRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.SparePartsRepository.Delete(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<SparePartDto>> Get(int rowsCount, string cacheKey) =>
            _mapper.Map<IEnumerable<SparePartDto>>(await _repositoryManager.SparePartsRepository.Get(rowsCount, cacheKey));

        public async Task<IEnumerable<SparePartDto>> GetAll()
        {
            var entities = await _repositoryManager.SparePartsRepository.GetAll(false);

            return _mapper.Map<IEnumerable<SparePartDto>>(entities);
        }


        public async Task<SparePartDto> GetById(Guid id)
        {
            var entity = await _repositoryManager.SparePartsRepository.GetById(id, false);

            return _mapper.Map<SparePartDto>(entity);
        }


        public async Task<bool> Update(SparePartForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.SparePartsRepository.GetById(entityForUpdate.Id, trackChanges: true);

            if (entity == null)
            {
                return false;
            }

            _mapper.Map(entityForUpdate, entity);

            _repositoryManager.SparePartsRepository.Update(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }
    }
}
