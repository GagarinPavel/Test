using System;

namespace CleaningManagement.Api.ViewModels.CleaningPlanViewModels
{
    public class CleaningPlanViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
