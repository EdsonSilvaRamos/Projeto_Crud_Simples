using AutoMapper;

namespace WebAPI.Profiles
{
    public class MapProfile<DTO, Modelo> : Profile
    {
        public MapProfile()
        {
            CreateMap<DTO, Modelo>();
        }

        public MapperConfiguration MapperConfiguration => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MapProfile<DTO, Modelo>>();
        });
    }
}