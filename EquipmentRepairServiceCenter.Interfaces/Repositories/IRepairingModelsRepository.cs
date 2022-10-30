﻿using EquipmentRepairServiceCenter.Domain.Models;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IRepairingModelsRepository
    {
        Task<IEnumerable<RepairingModel>> GetAll(bool trackChanges);
        Task<RepairingModel> GetById(Guid id, bool trackChanges);
        Task Create(RepairingModel entity);
        void Delete(RepairingModel entity);
        void Update(RepairingModel entity);
    }
}
