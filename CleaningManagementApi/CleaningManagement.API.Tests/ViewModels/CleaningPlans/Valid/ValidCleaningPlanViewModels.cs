using CleaningManagement.Api.ViewModels.CleaningPlanViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CleaningManagement.API.Tests.ViewModels.CleaningPlans.Valid
{
    public static class ValidCleaningPlanViewModels
    {
        public static readonly ShortCleaningPlanViewModel ValidCleaningPlanViewModel = new()
        {
            Title = "Title",    
            Description = "New descr",
            CustomerId = 12456,
        };

        public static readonly ShortCleaningPlanViewModel ValidCleaningPlanViewModelCreateInput = new()
        {
            Title = "Title",
            Description = "New descr Create",
            CustomerId = 12456,
        };

        public static readonly CleaningPlanViewModel ValidCleaningPlanViewModelCreateExpected = new()
        {
            Id = Guid.Parse("8e175f41-a144-4956-ae81-d81ae827d451"),
            Title = "Title",
            Description = "New descr Create",
            CustomerId = 12456,
            CreatedAt = DateTime.MaxValue,
        };

        public static readonly ShortCleaningPlanViewModel ValidCleaningPlanViewModelUpdateInput = new()
        {
            Title = "Title",
            Description = "New descr Create",
            CustomerId = 12456,
        };

        public static readonly CleaningPlanViewModel ValidCleaningPlanViewModelUpdateExpected = new()
        {
            Id = Guid.Parse("8e175f41-a124-4956-ae81-d81ae827d451"),
            Title = "Title",
            Description = "New descr Create",
            CustomerId = 12456,
            CreatedAt = DateTime.MaxValue,
        };

        public static readonly ImmutableList<ShortCleaningPlanViewModel> ValidCleaningPlansViewModelsGet = new List<ShortCleaningPlanViewModel>()
        {
            new ShortCleaningPlanViewModel{
                Title = "New title 12456",
                Description = "New descr 1245655",
                CustomerId = 12456
            },
            new ShortCleaningPlanViewModel{
                Title = "New title 2 12456",
                Description = "New descr 2 1245633",
                CustomerId = 12456
            }
        }.ToImmutableList();

        public static readonly ImmutableList<CleaningPlanViewModel> ValidCleaningPlansViewModelsGetByCustomerId = new List<CleaningPlanViewModel>()
        {
            new CleaningPlanViewModel{
                Title = "New title 12451",
                Description = "New descr 12451",
                CustomerId = 12451
            },
            new CleaningPlanViewModel{
                Title = "New title 2 12451",
                Description = "New descr 2 12451",
                CustomerId = 12451
            }
        }.ToImmutableList();
    }
}
