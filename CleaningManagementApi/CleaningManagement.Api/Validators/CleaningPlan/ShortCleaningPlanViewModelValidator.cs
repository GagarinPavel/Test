using CleaningManagement.Api.ViewModels.CleaningPlanViewModels;
using FluentValidation;

namespace CleaningManagement.Api.Validators.CleaningPlan
{
    public class ShortCleaningPlanViewModelValidator : AbstractValidator<ShortCleaningPlanViewModel>
    {
        public ShortCleaningPlanViewModelValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer id is empty");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is empty").MaximumLength(256).WithMessage("Title must be shorter");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description must be shorter");
        }
    }
}
