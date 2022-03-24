using CleaningManagement.BLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningManagement.BLL.Tests.Models.Valid
{
    public static class ValidCleaningPlanModels
    {
        public static readonly CleaningPlan CleaningPlanModelGetById = new()
        {
            Title = "New title GetById",
            Description = "New descr GetById",
            CustomerId = 12456,
        };

        public static readonly ImmutableList<CleaningPlan> CleaningPlansModelsGetAll = new List<CleaningPlan>()
        {
            new CleaningPlan{
                Title = "New title",
                Description = "New descr",
                CustomerId = 12456
            },
            new CleaningPlan{
                Title = "New title 2",
                Description = "New descr 2",
                CustomerId = 1245678
            }
        }.ToImmutableList();

        public static readonly ImmutableList<CleaningPlan> CleaningPlansModelsGetPlansByCustomerId = new List<CleaningPlan>()
        {
            new CleaningPlan{
                Title = "New title 12456",
                Description = "New descr 12456",
                CustomerId = 12456
            },
            new CleaningPlan{
                Title = "New title 2 12456",
                Description = "New descr 2 12456",
                CustomerId = 12456
            }
        }.ToImmutableList();

        public static readonly CleaningPlan CleaningPlanModelAdd = new()
        {
            Title = "New title Add",
            Description = "New descr Add",
            CustomerId = 12456,
        };

        public static readonly CleaningPlan CleaningPlanModelUpdate = new()
        {
            Title = "New title update",
            Description = "New descr update",
            CustomerId = 12456,
        };
    }
}
