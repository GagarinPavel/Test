using AIS.DAL.DI;
using CleaningManagement.BLL.Interfaces.Services;
using CleaningManagement.BLL.Services;
using CleaningManagement.DAL;
using CleaningManagement.DAL.Interfaces.Repositories;
using CleaningManagement.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AIS.BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBussinesLogic(this IServiceCollection services)
        {
            services.AddScoped<ICleaningPlanService, CleaningPlanService>();
            services.AddDataAccess();
        }
    }
}