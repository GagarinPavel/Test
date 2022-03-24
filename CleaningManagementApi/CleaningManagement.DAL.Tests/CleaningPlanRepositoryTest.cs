using CleaningManagement.DAL.Entity;
using CleaningManagement.DAL.Repositories;
using CleaningManagement.DAL.Tests.Entities.Invalid;
using CleaningManagement.DAL.Tests.Entities.Valid;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CleaningManagement.DAL.Tests
{
    public class CleaningPlanRepositoryTest
    {
        private CleaningPlanRepository _repository;

        [Fact]
        public async Task GetPlanById_ValidId_ReturnsPlanEntity()
        {
            var plan = ValidCleaningPlanEntities.CleaningPlanEntityGetById;

            await using CleaningManagementDbContext context = new();
            _repository = new(context);
            var entity = await context.CleaningPlans.AddAsync(plan);
            await context.SaveChangesAsync();

            var result = await _repository.GetById(entity.Entity.Id, default);

            result.ShouldNotBeNull();
            result.CustomerId.ShouldBe(entity.Entity.CustomerId);
            result.Title.ShouldBe(entity.Entity.Title);
        }

        [Fact]
        public async Task GetPlanByCustomerId_ValidId_ReturnsPlanEntityListByCustomerId()
        {
            var plan = ValidCleaningPlanEntities.CleaningPlansEntitiesGetPlansByCustomerId;

            await using CleaningManagementDbContext context = new();
            _repository = new(context);
            await context.CleaningPlans.AddRangeAsync(plan);
            await context.SaveChangesAsync();

            var result = await _repository.GetByCustomerId(plan[0].CustomerId, default);

            result.ShouldNotBeNull();
            plan.Count.ShouldBe(result.Count());
        }

        [Fact]
        public async Task GetPlans_ValidModels_ReturnsPlansEntityList()
        {
            var plans = ValidCleaningPlanEntities.CleaningPlansEntitiesGetAll;
            await using CleaningManagementDbContext context = new();
            _repository = new(context);
            context.CleaningPlans.AddRange(plans);

            await context.SaveChangesAsync();

            var result = await _repository.Get(default);

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task AddPlan_ValidModel_ReturnsPlanEntity()
        {
            var plan = ValidCleaningPlanEntities.CleaningPlanEntityCreate;

            await using CleaningManagementDbContext context = new();
            _repository = new(context);

            var result = await _repository.Create(plan, default);

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task UpdatePlan_ValidModel_ReturnsPlanEntity()
        {
            var addedEntity = ValidCleaningPlanEntities.CleaningPlanEntityAdd;
            var updatedEntity = ValidCleaningPlanEntities.CleaningPlanEntityUpdate;

            await using CleaningManagementDbContext context = new();
            _repository = new(context);
            var entity = await context.CleaningPlans.AddAsync(addedEntity);
            updatedEntity.Id = entity.Entity.Id;
            await context.SaveChangesAsync();
            context.Entry(entity.Entity).State = EntityState.Detached;

            var result = await _repository.Update(updatedEntity, default);

            result.ShouldNotBeNull();
            result.CustomerId.ShouldBe(updatedEntity.CustomerId);
            result.Title.ShouldBe(updatedEntity.Title);
        }

        [Fact]
        public async Task DeletePlan_ValidId_NotThrow()
        {
            var addedEntity = ValidCleaningPlanEntities.CleaningPlanEntityAdd;
            await using CleaningManagementDbContext context = new();
            _repository = new(context);

            var entity = context.CleaningPlans.Add(addedEntity);
            await context.SaveChangesAsync();

            await _repository.Delete(entity.Entity.Id, default).ShouldNotThrowAsync();
        }

        [Fact]
        public async Task GetPlanById_InvalidId_ReturnsNull()
        { 
            await using CleaningManagementDbContext context = new();
            _repository = new(context);

            await context.SaveChangesAsync();

            var employee = await _repository.GetById(Guid.NewGuid(), default);

            employee.ShouldBeNull();
        }

        [Fact]
        public async Task GetPlan_NoModels_ReturnsEmptyPlanEntityList()
        {
            await using CleaningManagementDbContext context = new();
            _repository = new(context);

            await context.Database.EnsureDeletedAsync();
            var result = await _repository.Get(default);

            result.ShouldBeEmpty();
        }

        [Fact]
        public async Task GetPlanByCustomerId_InvalidId_ReturnsEmptyPlanEntityList()
        {
            var plan = InvalidCleaningPlanEntities.InvalidCleaningPlansEntitiesGetPlansByCustomerId;

            await using CleaningManagementDbContext context = new();
            _repository = new(context);
            await context.CleaningPlans.AddRangeAsync(plan);
            await context.SaveChangesAsync();

            var result = await _repository.GetByCustomerId(plan[0].CustomerId+1, default);

            result.ShouldBeEmpty();
        }

        [Fact]
        public async Task AddPlan_InvalidModel_ThrowArgumentNullException()
        {
            await using CleaningManagementDbContext context = new();
            _repository = new(context);

            await _repository.Create(null, default).ShouldThrowAsync(typeof(ArgumentNullException));
        }

        [Fact]
        public async Task UpdatePlan_InvalidModel_ThrowDbUpdateConcurrencyException()
        {
            var expectedModel = InvalidCleaningPlanEntities.InvalidCleaningPlanEntityUpdate;

            var addedEntity = ValidCleaningPlanEntities.CleaningPlanEntityAdd;

            await using CleaningManagementDbContext context = new();
            _repository = new(context);

            await context.CleaningPlans.AddAsync(addedEntity);
            await context.SaveChangesAsync();

            await _repository.Update(expectedModel, default).ShouldThrowAsync(typeof(DbUpdateConcurrencyException));
        }

        [Fact]
        public async Task DeletePlan_InvalidId_ThrowDbUpdateConcurrencyException()
        {
            await using CleaningManagementDbContext context = new();
            _repository = new(context);
            await _repository.Delete(Guid.NewGuid(), default).ShouldThrowAsync(typeof(ArgumentNullException));
        }
    }
}
