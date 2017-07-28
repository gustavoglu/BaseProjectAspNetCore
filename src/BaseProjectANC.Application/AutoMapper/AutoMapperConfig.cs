using AutoMapper;

namespace BaseProjectANC.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelProfile>();
                cfg.AddProfile<ViewModelToDomainProfile>();
            });
        }
    }
}
