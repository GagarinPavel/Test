using AutoMapper;
using CleaningManagement.BLL.Interfaces.Services;
using CleaningManagement.BLL.Models;
using CleaningManagement.BLL.Services;
using CleaningManagement.BLL.Tests.Entities.Valid;
using CleaningManagement.BLL.Tests.Models.Valid;
using CleaningManagement.DAL.Entity;
using CleaningManagement.DAL.Interfaces.Repositories;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CleaningManagement.BLL.Tests
{
    public class CleaningPlanServiceTest
    {
        private readonly ICleaningPlanService _service;
        private readonly Mock<ICleaningPlanRepository> _cleaningPlanRepoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

        public CleaningPlanServiceTest()
        {
            _service = new CleaningPlanService(_cleaningPlanRepoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetPlans_HasData_ReturnsPlansList()
        {
            var plansModels = ValidCleaningPlanModels.CleaningPlansModelsGetAll;
            var plansEntities = ValidCleaningPlanEntities.CleaningPlansEntitiesGetAll;

            _mapperMock.Setup(x => x.Map<IEnumerable<CleaningPlan>>(It.IsAny<IEnumerable<CleaningPlanEntity>>()))
                .Returns(plansModels);
            _cleaningPlanRepoMock.Setup(x => x.Get(default)).ReturnsAsync(plansEntities);
            var result = await _service.Get(default);
            Assert.NotNull(result);
            Assert.Equal(plansModels.Count, result.Count());
            result.ShouldBeEquivalentTo(plansModels);
        }

        [Fact]
        public async Task GetPlanById_ValidId_ReturnsPlanById()
        {
            var planModel = ValidCleaningPlanModels.CleaningPlanModelGetById;
            var planEntitie = ValidCleaningPlanEntities.CleaningPlanEntityGetById;

            _mapperMock.Setup(x => x.Map<CleaningPlanEntity>(It.IsAny<CleaningPlan>())).Returns(planEntitie);
            _cleaningPlanRepoMock.Setup(x => x.GetById(It.IsAny<Guid>(), default)).ReturnsAsync(planEntitie);
            _mapperMock.Setup(x => x.Map<CleaningPlan>(It.IsAny<CleaningPlanEntity>())).Returns(planModel);
            // Act
            var result = await _service.GetById(planModel.Id, default);

            // Assert
            Assert.NotNull(result);
            result.ShouldBeEquivalentTo(planModel);
        }

        [Fact]
        public async Task GetPlansByCustomerId_ValidId_ReturnsPlansByCustomerId()
        {
            var plansModels = ValidCleaningPlanModels.CleaningPlansModelsGetPlansByCustomerId;
            var plansEntities = ValidCleaningPlanEntities.CleaningPlansEntitiesGetPlansByCustomerId;

            _mapperMock.Setup(x => x.Map<IEnumerable<CleaningPlan>>(It.IsAny<IEnumerable<CleaningPlanEntity>>()))
                 .Returns(plansModels);
            _cleaningPlanRepoMock.Setup(x => x.GetByCustomerId(It.IsAny<int>(), default)).ReturnsAsync(plansEntities);
            // Act
            var result = await _service.GetByCustomerId(22323, default);

            // Assert
            Assert.NotNull(result);
            result.ShouldBeEquivalentTo(plansModels);
        }

        [Fact]
        public async Task AddPlan_ValidPlan_ReturnsPlan()
        {
            var planModel = ValidCleaningPlanModels.CleaningPlanModelAdd;
            var planEntitie = ValidCleaningPlanEntities.CleaningPlanEntityAdd;
            _mapperMock.Setup(x => x.Map<CleaningPlanEntity>(It.IsAny<CleaningPlan>())).Returns(planEntitie);
            _cleaningPlanRepoMock.Setup(x => x.Create(It.IsAny<CleaningPlanEntity>(), default)).ReturnsAsync(planEntitie);
            _mapperMock.Setup(x => x.Map<CleaningPlan>(It.IsAny<CleaningPlanEntity>())).Returns(planModel);
            // Act
            var result = await _service.Create(planModel, default);

            // Assert
            Assert.NotNull(result);
            result.ShouldBeEquivalentTo(planModel);
        }

        [Fact]
        public async Task PutPlan_ValidPlan_ReturnsPlan()
        {
            var planModel = ValidCleaningPlanModels.CleaningPlanModelUpdate;
            var planEntitie = ValidCleaningPlanEntities.CleaningPlanEntityUpdate;
            _mapperMock.Setup(x => x.Map<CleaningPlanEntity>(It.IsAny<CleaningPlan>())).Returns(planEntitie);
            _cleaningPlanRepoMock.Setup(x => x.Update(It.IsAny<CleaningPlanEntity>(), default)).ReturnsAsync(planEntitie);
            _mapperMock.Setup(x => x.Map<CleaningPlan>(It.IsAny<CleaningPlanEntity>())).Returns(planModel);
            // Act
            var result = await _service.Update(planModel, default);

            // Assert
            Assert.NotNull(result);
            result.ShouldBeEquivalentTo(planModel);
        }

        [Fact]
        public async Task DeletePlan_ValidId_ReturnsNull()
        {
            var id = Guid.NewGuid();

            _cleaningPlanRepoMock.Setup(x => x.Delete(id, default));

            await _service.Delete(id, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task DeletePlan_InvalidId_ReturnsNull()
        {
            var id = Guid.NewGuid();

            _cleaningPlanRepoMock.Setup(x => x.Delete(id, default));

            await _service.Delete(id, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task GetPlans_NoData_ReturnsNull()
        {
            List<CleaningPlanEntity> planEntities = new();
            List<CleaningPlan> planModels = new();
            _cleaningPlanRepoMock.Setup(x => x.Get(default)).ReturnsAsync(planEntities);
            _mapperMock.Setup(x => x.Map<IEnumerable<CleaningPlan>>(It.IsAny<IEnumerable<CleaningPlanEntity>>())).Returns(planModels);
            var result = await _service.Get(default);
            Assert.Equal(new List<CleaningPlan>(), result);
        }

        [Fact]
        public async Task GetPlansById_InvalidId_ReturnsNull()
        {
            CleaningPlanEntity planEntity = new();
            CleaningPlan planModel = new();
            _cleaningPlanRepoMock.Setup(x => x.GetById(It.IsAny<Guid>(), default)).ReturnsAsync(planEntity);
            _mapperMock.Setup(x => x.Map<CleaningPlan>(It.IsAny<CleaningPlanEntity>())).Returns(planModel);
            var result = await _service.GetById(Guid.NewGuid(),default);
            Assert.Equal(planModel, result);
        }

        [Fact]
        public async Task GetPlansByCustomerId_InvalidCustomerId_ReturnsNull()
        {
            List<CleaningPlanEntity> planEntities = new();
            List<CleaningPlan> planModels = new();
            _cleaningPlanRepoMock.Setup(x => x.GetByCustomerId(It.IsAny<int>(), default)).ReturnsAsync(planEntities);
            _mapperMock.Setup(x => x.Map<IEnumerable<CleaningPlan>>(It.IsAny<IEnumerable<CleaningPlanEntity>>())).Returns(planModels);
            var result = await _service.GetByCustomerId(222, default);
            Assert.Equal(new List<CleaningPlan>(), result);
        }
    }
}
