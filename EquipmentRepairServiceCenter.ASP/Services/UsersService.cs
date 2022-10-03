using AutoMapper;
using EquipmentRepairServiceCenter.DTO.User;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;

namespace EquipmentRepairServiceCenter.ASP.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UsersService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repositoryManager.UsersRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.UsersRepository.Delete(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var entities = await _repositoryManager.UsersRepository.GetAll(false);

            return _mapper.Map<IEnumerable<UserDto>>(entities);
        }


        public async Task<UserDto> GetById(Guid id)
        {
            var entity = await _repositoryManager.UsersRepository.GetById(id, false);

            return _mapper.Map<UserDto>(entity);
        }
    }
}
