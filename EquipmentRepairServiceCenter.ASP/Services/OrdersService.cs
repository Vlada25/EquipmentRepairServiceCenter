using AutoMapper;
using EquipmentRepairServiceCenter.Domain;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.DTO.Order;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Services;

namespace EquipmentRepairServiceCenter.ASP.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrdersService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Order> Create(OrderForCreationDto entityForCreation)
        {
            var entity = _mapper.Map<Order>(entityForCreation);

            await _repositoryManager.OrdersRepository.Create(entity);
            await _repositoryManager.SaveAsync();

            return entity;
        }

        public async Task CreateMany()
        {
            var faults = await _repositoryManager.FaultsRepository.GetAll(false);
            var servicedStores = await _repositoryManager.ServicedStoresRepository.GetAll(false);

            DbInitializer.InitOrders(faults.ToList(), servicedStores.ToList());

            foreach (Order order in DbInitializer.Orders)
            {
                await _repositoryManager.OrdersRepository.Create(order);
            }

            await _repositoryManager.SaveAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repositoryManager.OrdersRepository.GetById(id, trackChanges: false);

            if (entity == null)
            {
                return false;
            }

            _repositoryManager.OrdersRepository.Delete(entity);
            await _repositoryManager.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<Order>> Get(int rowsCount, string cacheKey) =>
            await _repositoryManager.OrdersRepository.Get(rowsCount, cacheKey);

        public async Task<IEnumerable<Order>> GetAll() =>
            await _repositoryManager.OrdersRepository.GetAll(false);

        public async Task<IEnumerable<Order>> GetByClientId(Guid clientId) =>
            await _repositoryManager.OrdersRepository.GetByClientId(clientId);

        public async Task<IEnumerable<Order>> GetByEmployeeId(Guid employeeId) =>
            await _repositoryManager.OrdersRepository.GetByEmployeeId(employeeId);

        public async Task<Order> GetById(Guid id) =>
            await _repositoryManager.OrdersRepository.GetById(id, false);

        public async Task<bool> Update(OrderForUpdateDto entityForUpdate)
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
