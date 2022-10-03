using EquipmentRepairServiceCenter.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
