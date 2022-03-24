using CleaningManagement.Api.ViewModels.CleaningPlanViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningManagement.API.Tests.ViewModels.CleaningPlans.Invalid
{
    public static class InvalidCleaningPlanViewModels
    {
        public static readonly ShortCleaningPlanViewModel InvalidCleaningPlanViewModelWihthoutTitle = new()
        {
            Description = "New descr Add",
            CustomerId = 12456,
        };

        public static readonly ShortCleaningPlanViewModel InvalidCleaningPlanViewModelWihthoutCustomerId = new()
        {
            Description = "New descr Add",
            Title = "dsdsdwd",
        };
        public static readonly ShortCleaningPlanViewModel InvalidCleaningPlanViewModelBiggerTitle = new()
        {
            CustomerId = 12456,
            Description = "New descr",
            Title = $@"Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of  (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum
The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested.Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form,
            accompanied by English versions from the 1914 translation by H.Rackham.",
        };

        public static readonly ShortCleaningPlanViewModel InvalidCleaningPlanViewModelBiggerDescription = new()
        {
            CustomerId = 12456,
            Title = "New descr Add",
            Description = $@"Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of  (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum
The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested.Sections 1.10.32 and 1.10.33 from de Finibus Bonorum et Malorum by Cicero are also reproduced in their exact original form,
            accompanied by English versions from the 1914 translation by H.Rackham.",
        };
    }
}
