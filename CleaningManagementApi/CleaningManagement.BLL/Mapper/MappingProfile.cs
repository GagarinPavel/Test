using AutoMapper;
using CleaningManagement.BLL.Models;
using CleaningManagement.DAL.Entity;

namespace CleaningManagement.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CleaningPlan, CleaningPlanEntity>().ReverseMap();
        }
    }
}
