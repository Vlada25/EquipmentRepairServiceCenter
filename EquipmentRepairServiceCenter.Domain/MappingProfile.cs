using AutoMapper;
using EquipmentRepairServiceCenter.Domain.Extensions;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.Domain.Models.User;
using EquipmentRepairServiceCenter.DTO.Client;
using EquipmentRepairServiceCenter.DTO.Employee;
using EquipmentRepairServiceCenter.DTO.Fault;
using EquipmentRepairServiceCenter.DTO.Order;
using EquipmentRepairServiceCenter.DTO.RepairingModel;
using EquipmentRepairServiceCenter.DTO.ServicedStore;
using EquipmentRepairServiceCenter.DTO.SparePart;
using EquipmentRepairServiceCenter.DTO.UsedSparePart;
using EquipmentRepairServiceCenter.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientForCreationDto, Client>();
            CreateMap<ClientForUpdateDto, Client>();

            CreateMap<Employee, EmployeeDto>()
                .ForMember(e => e.Position, opt => opt.MapFrom(x => EnumExtensions.GetDisplayName(x.Position)));
            CreateMap<EmployeeForCreationDto, Employee>()
                .ForMember(e => e.Position, opt => opt.MapFrom(x => EnumExtensions.SetPosition(x.Position)));
            CreateMap<EmployeeForUpdateDto, Employee>();

            CreateMap<RepairingModel, RepairingModelDto>()
                .ForMember(rm => rm.Type, opt => opt.MapFrom(x => EnumExtensions.GetDisplayName(x.Type)));
            CreateMap<RepairingModelForCreationDto, RepairingModel>()
                .ForMember(rm => rm.Type, opt => opt.MapFrom(x => EnumExtensions.SetEquipmentType(x.Type)));
            CreateMap<RepairingModelForUpdateDto, RepairingModel>();

            CreateMap<FaultForCreationDto, Fault>();
            CreateMap<FaultForUpdateDto, Fault>();

            CreateMap<OrderForCreationDto, Order>();
            CreateMap<OrderForUpdateDto, Order>();

            CreateMap<ServicedStoreForCreationDto, ServicedStore>();
            CreateMap<ServicedStoreForUpdateDto, ServicedStore>();

            CreateMap<SparePart, SparePartDto>()
                .ForMember(sp => sp.EquipmentType, opt => opt.MapFrom(x => EnumExtensions.GetDisplayName(x.EquipmentType)));
            CreateMap<SparePartForCreationDto, SparePart>()
                .ForMember(sp => sp.EquipmentType, opt => opt.MapFrom(x => EnumExtensions.SetEquipmentType(x.EquipmentType)));
            CreateMap<SparePartForUpdateDto, SparePart>();

            CreateMap<UsedSparePartForCreationDto, UsedSparePart>();

            CreateMap<User, UserDto>();
        }
    }
}
