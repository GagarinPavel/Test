using AutoMapper;
using CleaningManagement.Api.ViewModels.CleaningPlanViewModels;
using CleaningManagement.BLL.Models;

namespace CleaningManagement.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CleaningPlanViewModel, CleaningPlan>().ReverseMap();
            CreateMap<CleaningPlan, ShortCleaningPlanViewModel>().ReverseMap();
        }
    }
}
