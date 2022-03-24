using CleaningManagement.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningManagement.DAL.Tests.Entities.Invalid
{
    public static class InvalidCleaningPlanEntities
    {
        public static readonly CleaningPlanEntity InvalidCleaningPlanEntityUpdate = new()
        {
            Description = "New descr update",
        };

        public static readonly ImmutableList<CleaningPlanEntity> InvalidCleaningPlansEntitiesGetPlansByCustomerId = new List<CleaningPlanEntity>()
        {
            new CleaningPlanEntity{
                Title = "New title 2345",
                Description = "New descr 2345",
                CustomerId = 2345
            },
            new CleaningPlanEntity{
                Title = "New title 2 2345",
                Description = "New descr 2 2345",
                CustomerId = 2345
            }
        }.ToImmutableList();
    }
}
