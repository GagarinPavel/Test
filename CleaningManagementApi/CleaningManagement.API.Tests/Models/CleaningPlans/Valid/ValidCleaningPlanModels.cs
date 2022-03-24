using CleaningManagement.BLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CleaningManagement.API.Tests.Models.CleaningPlans.Valid
{
    public static class ValidCleaningPlanModels
    {
        public static readonly CleaningPlan ValidCleaningPlanModelCreateInput = new()
        {
            Title = "Title",    
            Description = "New descr create",
            CustomerId = 12456,
        };

        public static readonly CleaningPlan ValidCleaningPlanModelCreateExpected = new()
        {
            Id = Guid.Parse("8e175f41-a144-4956-ae81-d81ae827d451"),
            Title = "Title",
            Description = "New descr create",
            CustomerId = 12456,
            CreatedAt = DateTime.MaxValue
        };

        public static readonly CleaningPlan ValidCleaningPlanModelUpdateInput = new()
        {
            Id = Guid.Parse("8e175f41-a124-4956-ae81-d81ae827d451"),
            Title = "Title",
            Description = "New descr Create",
            CustomerId = 12456,
        };

        public static readonly CleaningPlan ValidCleaningPlanModelUpdateExpected = new()
        {
            Id = Guid.Parse("8e175f41-a124-4956-ae81-d81ae827d451"),
            Title = "Title",
            Description = "New descr Create",
            CustomerId = 12456,
            CreatedAt = DateTime.MaxValue,
        };

        public static readonly ImmutableList<CleaningPlan> ValidCleaningPlansModelsGet = new List<CleaningPlan>()
        {
            new CleaningPlan{
                Title = "New title 12456",
                Description = "New descr 1245655",
                CustomerId = 12456
            },
            new CleaningPlan{
                Title = "New title 2 12456",
                Description = "New descr 2 1245633",
                CustomerId = 12456
            }
        }.ToImmutableList();

        public static readonly ImmutableList<CleaningPlan> ValidCleaningPlansModelsGetByCustomerId = new List<CleaningPlan>()
        {
            new CleaningPlan{
                Title = "New title 12451",
                Description = "New descr 12451",
                CustomerId = 12451
            },
            new CleaningPlan{
                Title = "New title 2 12451",
                Description = "New descr 2 12451",
                CustomerId = 12451
            }
        }.ToImmutableList();
    }
}
