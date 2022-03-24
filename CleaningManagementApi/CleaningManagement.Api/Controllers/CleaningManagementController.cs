using AutoMapper;
using CleaningManagement.Api.ViewModels.CleaningPlanViewModels;
using CleaningManagement.BLL.Interfaces.Services;
using CleaningManagement.BLL.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleaningManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CleaningManagementController : ControllerBase
    {
        private readonly ICleaningPlanService _cleaningPlanService;
        private readonly IMapper _mapper;
        private readonly IValidator<ShortCleaningPlanViewModel> _validator;

        public CleaningManagementController(
                        ICleaningPlanService cleaningPlanService,
                        IMapper mapper,
                        IValidator<ShortCleaningPlanViewModel> validator)
        {
            _cleaningPlanService = cleaningPlanService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<CleaningPlanViewModel>> GetByCustomerId(int id, CancellationToken ct)
        {
            var cleaningPlan = _mapper.Map<IEnumerable<CleaningPlanViewModel>>(await _cleaningPlanService.GetByCustomerId(id, ct));
            return cleaningPlan;
        }

        [HttpGet]
        public async Task<IEnumerable<ShortCleaningPlanViewModel>> GetCleaningPlans(CancellationToken ct)
        {
            var cleaningPlan = await _cleaningPlanService.Get(ct);
            return _mapper.Map<IEnumerable<ShortCleaningPlanViewModel>>(cleaningPlan);
        }

        [HttpPost]
        public async Task<CleaningPlanViewModel> Post(ShortCleaningPlanViewModel cleaningPlan, CancellationToken ct)
        {
            await _validator.ValidateAndThrowAsync(cleaningPlan, ct);

            return _mapper.Map<CleaningPlanViewModel>(
                await _cleaningPlanService.Create(_mapper.Map<CleaningPlan>(cleaningPlan), ct)
                );
        }

        [HttpPut]
        public async Task<CleaningPlanViewModel> Put(ShortCleaningPlanViewModel cleaningPlan, Guid id, CancellationToken ct)
        {
            await _validator.ValidateAndThrowAsync(cleaningPlan, ct);

            var model = _mapper.Map<CleaningPlan>(cleaningPlan);
            model.Id = id;

            return _mapper.Map<CleaningPlanViewModel>(
                await _cleaningPlanService.Update(model, ct)
            );
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id, CancellationToken ct)
        {
            return _cleaningPlanService.Delete(id, ct);
        }
    }
}