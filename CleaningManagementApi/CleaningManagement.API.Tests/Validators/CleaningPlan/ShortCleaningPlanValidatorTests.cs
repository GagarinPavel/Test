using CleaningManagement.Api.Validators.CleaningPlan;
using CleaningManagement.API.Tests.ViewModels.CleaningPlans.Invalid;
using CleaningManagement.API.Tests.ViewModels.CleaningPlans.Valid;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleaningManagement.API.Tests.Validators.CleaningPlan
{
    public class ShortCleaningPlanValidatorTests
    {
        [Fact]
        public void Validate_ValidModel_ReturnsTrue()
        {
            var validator = new ShortCleaningPlanViewModelValidator();

            var model = ValidCleaningPlanViewModels.ValidCleaningPlanViewModel;

            // Act
            var result = validator.Validate(model);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_ModelWithoutTitle_ReturnsFalse()
        {
            var validator = new ShortCleaningPlanViewModelValidator();

            var model = InvalidCleaningPlanViewModels.InvalidCleaningPlanViewModelWihthoutTitle;

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Title));
        }
        [Fact]
        public void Validate_ModelWithoutCustomerId_ReturnsFalse()
        {
            var validator = new ShortCleaningPlanViewModelValidator();

            var model = InvalidCleaningPlanViewModels.InvalidCleaningPlanViewModelWihthoutCustomerId;

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.CustomerId));
        }
        [Fact]
        public void Validate_ModelWithBigTitle_ReturnsFalse()
        {
            var validator = new ShortCleaningPlanViewModelValidator();

            var model = InvalidCleaningPlanViewModels.InvalidCleaningPlanViewModelBiggerTitle;

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Title));
        }
        [Fact]
        public void Validate_ModelWithBigDescription_ReturnsFalse()
        {
            var validator = new ShortCleaningPlanViewModelValidator();

            var model = InvalidCleaningPlanViewModels.InvalidCleaningPlanViewModelBiggerDescription;

            // Act
            var result = validator.Validate(model);

            // Assert
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(x => x.PropertyName == nameof(model.Description));
        }
    }
}
