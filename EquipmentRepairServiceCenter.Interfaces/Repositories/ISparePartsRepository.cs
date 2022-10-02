﻿using EquipmentRepairServiceCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface ISparePartsRepository
    {
        Task<IEnumerable<SparePart>> GetAll(bool trackChanges);
        Task<SparePart> GetById(Guid id, bool trackChanges);
        Task Create(SparePart entity);
        Task Create(IEnumerable<SparePart> entities);
        Task Delete(SparePart entity);
        Task Update(SparePart entity);
    }
}
