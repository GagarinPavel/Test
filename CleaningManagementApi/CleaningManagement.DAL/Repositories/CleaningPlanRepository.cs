using CleaningManagement.DAL.Entity;
using CleaningManagement.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleaningManagement.DAL.Repositories
{
    public class CleaningPlanRepository : GenericRepository<CleaningPlanEntity>, ICleaningPlanRepository
    {
        public CleaningPlanRepository(CleaningManagementDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CleaningPlanEntity>> GetByCustomerId(int id, CancellationToken ct)
        {
            return await _context.CleaningPlans.Where((plan)=>plan.CustomerId == id).ToListAsync(ct);
        }
    }
}
