using CleaningManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CleaningManagement.DAL.Tests.Entities.Valid
{
    public static class ValidCleaningPlanEntities
    {
        public static readonly CleaningPlanEntity CleaningPlanEntityGetById = new()
        {
            Title = "New title GetById",
            Description = "New descr GetById",
            CustomerId = 124561,
        };

        public static readonly ImmutableList<CleaningPlanEntity> CleaningPlansEntitiesGetAll = new List<CleaningPlanEntity>()
        {
            new CleaningPlanEntity{
                Title = "New title",
                Description = "New descr",
                CustomerId = 124563
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
            CustomerId = 124560,
        };

        public static readonly CleaningPlanEntity CleaningPlanEntityCreate = new()
        {
            Title = "New title create",
            Description = "New descr create",
            CustomerId = 12224569,
        };

        public static readonly CleaningPlanEntity CleaningPlanEntityUpdate = new()
        {
            Title = "New title update",
            Description = "New descr update",
            CustomerId = 1245655,
        };

    }
}
