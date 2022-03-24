using CleaningManagement.DAL.Entity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleaningManagement.DAL.Interfaces.Repositories
{
    public interface ICleaningPlanRepository: IGenericRepository<CleaningPlanEntity>
    {
        Task<IEnumerable<CleaningPlanEntity>> GetByCustomerId(int id, CancellationToken ct);
    }
}
