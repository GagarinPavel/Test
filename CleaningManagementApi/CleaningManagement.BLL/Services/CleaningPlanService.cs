using AutoMapper;
using CleaningManagement.BLL.Interfaces.Services;
using CleaningManagement.BLL.Models;
using CleaningManagement.DAL.Entity;
using CleaningManagement.DAL.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleaningManagement.BLL.Services
{
    public class CleaningPlanService : GenericService<CleaningPlan, CleaningPlanEntity>, ICleaningPlanService
    {
        private readonly ICleaningPlanRepository _repository;
        private readonly IMapper _mapper;
        public CleaningPlanService(ICleaningPlanRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CleaningPlan>> GetByCustomerId(int id, CancellationToken ct)
        {
            return _mapper.Map<IEnumerable<CleaningPlan>>(await _repository.GetByCustomerId(id, ct));
        }
    }
}
