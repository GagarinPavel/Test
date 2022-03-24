using CleaningManagement.BLL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleaningManagement.BLL.Interfaces.Services
{
    public interface ICleaningPlanService : IGenericService<CleaningPlan>
    {
        Task<IEnumerable<CleaningPlan>> GetByCustomerId(int id, CancellationToken ct);
    }
}
