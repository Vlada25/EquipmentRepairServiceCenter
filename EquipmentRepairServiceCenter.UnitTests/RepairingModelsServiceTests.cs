using AutoMapper;
using EquipmentRepairServiceCenter.ASP.Services;
using EquipmentRepairServiceCenter.Domain;
using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.Domain.Models.Enums;
using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.DTO.RepairingModel;
using EquipmentRepairServiceCenter.Interfaces;
using EquipmentRepairServiceCenter.Interfaces.Repositories;
using EquipmentRepairServiceCenter.Interfaces.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using System;
using Xunit;

namespace EquipmentRepairServiceCenter.UnitTests
{
    public class RepairingModelsServiceTests
    {
        private readonly Mock<IRepositoryManager> _repositoryManager;
        private static IMapper _mapper;

        public RepairingModelsServiceTests()
        {
            _repositoryManager = new Mock<IRepositoryManager>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        private List<RepairingModel> _testModels = new List<RepairingModel>
        {
            new RepairingModel
            {
                Id = new Guid("3e77e8aa-b920-4bca-adb6-4a5e2de117f2"),
                Name = "Fridge Atlant",
                Type = EquipmentType.Refrigerator,
                Manufacturer = "Atlant"
            },
            new RepairingModel
            {
                Id = new Guid("7e1ca877-fb7a-46d0-b3d6-e0e102d5b6ad"),
                Name = "Iron Philips",
                Type = EquipmentType.Iron,
                Manufacturer = "Philips"
            },
            new RepairingModel
            {
                Id = new Guid("e3d934ae-4002-41b7-8dcf-99709425f227"),
                Name = "Telephone Xiaomi",
                Type = EquipmentType.Telephone,
                Manufacturer = "Xiaomi"
            },
        };

        private List<RepairingModelDto> _testModelsDto = new List<RepairingModelDto>
        {
            new RepairingModelDto
            {
                Id = new Guid("3e77e8aa-b920-4bca-adb6-4a5e2de117f2"),
                Name = "Fridge Atlant",
                Type = "Refrigerator",
                Manufacturer = "Atlant"
            },
            new RepairingModelDto
            {
                Id = new Guid("7e1ca877-fb7a-46d0-b3d6-e0e102d5b6ad"),
                Name = "Iron Philips",
                Type = "Iron",
                Manufacturer = "Philips"
            },
            new RepairingModelDto
            {
                Id = new Guid("e3d934ae-4002-41b7-8dcf-99709425f227"),
                Name = "Telephone Xiaomi",
                Type = "Telephone",
                Manufacturer = "Xiaomi"
            },
        };


        [Fact]
        public async Task GetAll_RepairingModelsExist_ReturnsListOfRepairingModelsDto()
        {
            // Arrange
            _repositoryManager.Setup(r => r.RepairingModelsRepository.GetAll(false))
                .ReturnsAsync(_testModels);
            var service = new RepairingModelsService(_repositoryManager.Object, _mapper);

            // Act
            var result = await service.GetAll();

            // Assert
            result.Should().HaveSameCount(_testModels);
            result.Should().BeEquivalentTo(_testModelsDto);
        }


        [Fact]
        public async Task GetAll_RepairingModelsNotExist_ReturnsEmpty()
        {
            // Arrange
            _repositoryManager.Setup(r => r.RepairingModelsRepository.GetAll(false))
                .ReturnsAsync(new List<RepairingModel>());
            var service = new RepairingModelsService(_repositoryManager.Object, _mapper);

            // Act
            var result = await service.GetAll();

            // Assert
            result.Should().HaveCount(0);
        }


        [Fact]
        public async Task GetById_RepairingModelExists_ReturnsRepairingModelDto()
        {
            // Arrange
            var repairingModel = _testModels[0];
            var repairingModelDto = _testModelsDto[0];

            _repositoryManager.Setup(r => r.RepairingModelsRepository.GetById(repairingModel.Id, false))
                .ReturnsAsync(repairingModel);
            var service = new RepairingModelsService(_repositoryManager.Object, _mapper);

            // Act
            var result = await service.GetById(repairingModel.Id);

            // Assert
            result.Should().BeEquivalentTo(repairingModelDto);
        }


        [Fact]
        public async Task GetById_RepairingModelDoesntExist_ReturnsNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _repositoryManager.Setup(r => r.RepairingModelsRepository.GetById(id, false))
                .ReturnsAsync((RepairingModel)null);
            var service = new RepairingModelsService(_repositoryManager.Object, _mapper);

            // Act
            var result = await service.GetById(id);

            // Assert
            result.Should().BeNull();
        }


        [Fact]
        public async Task Create_RepairingModelValid_ReturnsRepairingModelDto()
        {
            // Arrange
            RepairingModel repairingModel = new RepairingModel
            {
                Name = "Fridge Atlant",
                Type = EquipmentType.Refrigerator,
                Manufacturer = "Atlant"
            };

            RepairingModelDto repairingModelDto = new RepairingModelDto
            {
                Name = "Fridge Atlant",
                Type = "Refrigerator",
                Manufacturer = "Atlant"
            };

            RepairingModelForCreationDto repairingModelForCreation = new RepairingModelForCreationDto
            {
                Name = "Fridge Atlant",
                Type = "Refrigerator",
                Manufacturer = "Atlant"
            };

            _repositoryManager.Setup(r => r.RepairingModelsRepository.Create(repairingModel));
            var service = new RepairingModelsService(_repositoryManager.Object, _mapper);

            // Act
            var result = await service.Create(repairingModelForCreation);

            // Assert
            result.Should().BeEquivalentTo(repairingModelDto);
        }


        [Fact]
        public async Task Create_RepairingModelInvalid_ThrowsException()
        {
            // Arrange
            _repositoryManager.Setup(r => r.RepairingModelsRepository.Create(null))
                .ThrowsAsync(new Exception());
            var service = new RepairingModelsService(_repositoryManager.Object, _mapper);

            // Act
            Func<Task> result = () => service.Create(null);

            // Assert
            await result.Should().ThrowAsync<Exception>();
        }
    }
}