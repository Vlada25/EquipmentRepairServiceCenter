using EquipmentRepairServiceCenter.Database.Repositories;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace EquipmentRepairServiceCenter.Database
{
    public class RepositoryManager : IRepositoryManager
    {
        private AppDbContext _dbContext;
        private IMemoryCache _memoryCache;

        private IClientsRepository _clientsRepository;
        private IEmployeesRepository _employeesRepository;
        private IFaultsRepository _faultsRepository;
        private IOrdersRepository _ordersRepository;
        private IRepairingModelsRepository _repairingModelsRepository;
        private IServicedStoresRepository _servicedStoresRepository;
        private ISparePartsRepository _sparePartsRepository;
        private IUsedSparePartsRepository _usedSparePartsRepository;

        public RepositoryManager(AppDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public IClientsRepository ClientsRepository
        {
            get
            {
                if (_clientsRepository == null)
                {
                    _clientsRepository = new ClientsRepository(_dbContext, _memoryCache);
                }
                return _clientsRepository;
            }
        }

        public IEmployeesRepository EmployeesRepository
        {
            get
            {
                if (_employeesRepository == null)
                {
                    _employeesRepository = new EmployeesRepository(_dbContext, _memoryCache);
                }
                return _employeesRepository;
            }
        }

        public IFaultsRepository FaultsRepository
        {
            get
            {
                if (_faultsRepository == null)
                {
                    _faultsRepository = new FaultsRepository(_dbContext, _memoryCache);
                }
                return _faultsRepository;
            }
        }

        public IOrdersRepository OrdersRepository
        {
            get
            {
                if (_ordersRepository == null)
                {
                    _ordersRepository = new OrdersRepository(_dbContext, _memoryCache);
                }
                return _ordersRepository;
            }
        }

        public IServicedStoresRepository ServicedStoresRepository
        {
            get
            {
                if (_servicedStoresRepository == null)
                {
                    _servicedStoresRepository = new ServicedStoresRepository(_dbContext, _memoryCache);
                }
                return _servicedStoresRepository;
            }
        }

        public ISparePartsRepository SparePartsRepository
        {
            get
            {
                if (_sparePartsRepository == null)
                {
                    _sparePartsRepository = new SparePartsRepository(_dbContext, _memoryCache);
                }
                return _sparePartsRepository;
            }
        }

        public IRepairingModelsRepository RepairingModelsRepository
        {
            get
            {
                if (_repairingModelsRepository == null)
                {
                    _repairingModelsRepository = new RepairingModelsRepository(_dbContext, _memoryCache);
                }
                return _repairingModelsRepository;
            }
        }

        public IUsedSparePartsRepository UsedSparePartsRepository
        {
            get
            {
                if (_usedSparePartsRepository == null)
                {
                    _usedSparePartsRepository = new UsedSparePartsRepository(_dbContext, _memoryCache);
                }
                return _usedSparePartsRepository;
            }
        }

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
