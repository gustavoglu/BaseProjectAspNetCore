using AutoMapper;
using BaseProjectANC.Application.ViewModels;
using BaseProjectANC.Domain.Models.EntitySample;

namespace BaseProjectANC.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<EntitySample, EntitySampleViewModel>();  
        }
    }
}
