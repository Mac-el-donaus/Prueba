using AutoMapper;
using Prueba___API.Modelos;
using Prueba___API.Modelos.Dto;

namespace Prueba___API
{
    public class MappingConfig : Profile
    {

        public MappingConfig()
        {
            CreateMap<Prueba, PruebaDto>();
            CreateMap<PruebaDto, Prueba>();

            CreateMap<Prueba, PruebaCreateDto>().ReverseMap();
            CreateMap<Prueba, PruebaUpdateDto>().ReverseMap();
        }
    }
}
