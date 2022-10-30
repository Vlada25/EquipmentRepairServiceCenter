using EquipmentRepairServiceCenter.Interfaces.Repositories;

namespace EquipmentRepairServiceCenter.Interfaces
{
    public interface IRepositoryManager
    {
        IClientsRepository ClientsRepository { get; }
        IEmployeesRepository EmployeesRepository { get; }
        IFaultsRepository FaultsRepository { get; }
        IOrdersRepository OrdersRepository { get; }
        IRepairingModelsRepository RepairingModelsRepository { get; }
        IServicedStoresRepository ServicedStoresRepository { get; }
        ISparePartsRepository SparePartsRepository { get; }
        IUsedSparePartsRepository UsedSparePartsRepository { get; }

        Task SaveAsync();
    }
}
