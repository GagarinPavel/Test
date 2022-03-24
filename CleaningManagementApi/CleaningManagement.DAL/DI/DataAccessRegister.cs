using CleaningManagement.DAL;
using CleaningManagement.DAL.Interfaces.Repositories;
using CleaningManagement.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AIS.DAL.DI
{
    public static class DataAccessRegister
    {
        public static void AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<ICleaningPlanRepository, CleaningPlanRepository>();

            services.AddDbContext<CleaningManagementDbContext>();
        }
    }
}