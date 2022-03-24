using CleaningManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningManagement.BLL.Tests.Entities.Valid
{
    public static class ValidCleaningPlanEntities
    {
        public static readonly CleaningPlanEntity CleaningPlanEntityGetById = new()
        {
            Title = "New title GetById",
            Description = "New descr GetById",
            CustomerId = 12456,
        };

        public static readonly ImmutableList<CleaningPlanEntity> CleaningPlansEntitiesGetAll = new List<CleaningPlanEntity>()
        {
            new CleaningPlanEntity{
                Title = "New title",
                Description = "New descr",
                CustomerId = 12456
            },
            new CleaningPlanEntity{
                Title = "New title 2",
                Description = "New descr 2",
                CustomerId = 1245678
            }
        }.ToImmutableList();

        public static readonly ImmutableList<CleaningPlanEntity> CleaningPlansEntitiesGetPlansByCustomerId = new List<CleaningPlanEntity>()
        {
            new CleaningPlanEntity{
                Title = "New title 12456",
                Description = "New descr 12456",
                CustomerId = 12456
            },
            new CleaningPlanEntity{
                Title = "New title 2 12456",
                Description = "New descr 2 12456",
                CustomerId = 12456
            }
        }.ToImmutableList();

        public static readonly CleaningPlanEntity CleaningPlanEntityAdd = new()
        {
            Title = "New title Add",
            Description = "New descr Add",
            CustomerId = 12456,
        };

        public static readonly CleaningPlanEntity CleaningPlanEntityUpdate = new()
        {
            Title = "New title update",
            Description = "New descr update",
            CustomerId = 12456,
        };
    }
}
