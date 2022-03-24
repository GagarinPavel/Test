using AutoMapper;
using CleaningManagement.Api.Controllers;
using CleaningManagement.Api.ViewModels.CleaningPlanViewModels;
using CleaningManagement.API.Tests.Models.CleaningPlans.Valid;
using CleaningManagement.API.Tests.ViewModels.CleaningPlans.Valid;
using CleaningManagement.BLL.Interfaces.Services;
using CleaningManagement.BLL.Models;
using FluentValidation;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleaningManagement.API.Tests.Controllers
{
    public class CleaningManagementControllerTests
    {
        private readonly Mock<IValidator<ShortCleaningPlanViewModel>> _validatorMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<ICleaningPlanService> _serviceMock = new();

        [Fact]
        public async Task Create_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputViewModel = ValidCleaningPlanViewModels.ValidCleaningPlanViewModelCreateInput;
            var inputModel = ValidCleaningPlanModels.ValidCleaningPlanModelCreateInput;
            var expectedViewModel = ValidCleaningPlanViewModels.ValidCleaningPlanViewModelCreateExpected;
            var expectedModel = ValidCleaningPlanModels.ValidCleaningPlanModelCreateExpected;

            _validatorMock.Setup(valid => valid.Validate(inputViewModel));
            _mapperMock.Setup(map => map.Map<CleaningPlan>(It.IsAny<ShortCleaningPlanViewModel>())).Returns(inputModel);
            _mapperMock.Setup(map => map.Map<CleaningPlanViewModel>(It.IsAny<CleaningPlan>())).Returns(expectedViewModel);
            _serviceMock.Setup(serv => serv.Create(It.IsAny<CleaningPlan>(), default)).ReturnsAsync(expectedModel);

            var controller = new CleaningManagementController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Post(inputViewModel, default);

            // Assert
            inputViewModel.Title.ShouldBeEquivalentTo(result.Title);
        }

        [Fact]
        public async Task Update_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var inputViewModel = ValidCleaningPlanViewModels.ValidCleaningPlanViewModelUpdateInput;
            var inputModel = ValidCleaningPlanModels.ValidCleaningPlanModelUpdateInput;
            var expectedViewModel = ValidCleaningPlanViewModels.ValidCleaningPlanViewModelUpdateExpected;
            var expectedModel = ValidCleaningPlanModels.ValidCleaningPlanModelUpdateExpected;

            _validatorMock.Setup(valid => valid.Validate(inputViewModel));
            _mapperMock.Setup(map => map.Map<CleaningPlan>(It.IsAny<ShortCleaningPlanViewModel>())).Returns(inputModel);
            _mapperMock.Setup(map => map.Map<CleaningPlanViewModel>(It.IsAny<CleaningPlan>())).Returns(expectedViewModel);
            _serviceMock.Setup(serv => serv.Update(It.IsAny<CleaningPlan>(), default)).ReturnsAsync(expectedModel);


            var controller = new CleaningManagementController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.Put(inputViewModel, Guid.Parse("8e175f41-a124-4956-ae81-d81ae827d451"), default);

            // Assert
            inputViewModel.Title.ShouldBeEquivalentTo(result.Title);
        }

        [Fact]
        public async Task Get_WhenControllerHasData_ShouldReturnValidModel()
        {
            // Arrange
            var expectedViewModels = ValidCleaningPlanViewModels.ValidCleaningPlansViewModelsGet.ToList();
            var expectedModels = ValidCleaningPlanModels.ValidCleaningPlansModelsGet;

            _mapperMock.Setup(map => map.Map<IEnumerable<ShortCleaningPlanViewModel>>(It.IsAny<IEnumerable<CleaningPlan>>()))
                .Returns(expectedViewModels);
            _serviceMock.Setup(serv => serv.Get(default)).ReturnsAsync(expectedModels);

            var controller = new CleaningManagementController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.GetCleaningPlans(default);

            int i = 1;
            // Assert
            expectedViewModels.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Delete_ValidId_NoReturn()
        {

            _serviceMock.Setup(serv => serv.Delete(It.IsAny<Guid>(), default));

            var controller = new CleaningManagementController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            await controller.Delete(Guid.NewGuid(), default).ShouldNotThrowAsync();

        }

        [Fact]
        public async Task GetCompanyByCustomerId_ValidId_ShouldReturnValidModels()
        {
            var expectedViewModels = ValidCleaningPlanViewModels.ValidCleaningPlansViewModelsGetByCustomerId;
            var expectedModels = ValidCleaningPlanModels.ValidCleaningPlansModelsGetByCustomerId;

            _mapperMock.Setup(map => map.Map<IEnumerable<CleaningPlanViewModel>>(It.IsAny<IEnumerable<CleaningPlan>>()))
                .Returns(expectedViewModels);
            _serviceMock.Setup(serv => serv.GetByCustomerId(It.IsAny<int>() ,default)).ReturnsAsync(expectedModels);

            var controller = new CleaningManagementController(_serviceMock.Object, _mapperMock.Object, _validatorMock.Object);

            // Act
            var result = await controller.GetByCustomerId(12451, default);

            // Assert
            expectedViewModels.ShouldBeEquivalentTo(result);
        }
    }
}
