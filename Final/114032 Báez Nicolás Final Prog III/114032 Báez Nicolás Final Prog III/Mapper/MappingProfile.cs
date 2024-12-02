using _114032_Báez_Nicolás_Final_Prog_III.Dominio;
using _114032_Báez_Nicolás_Final_Prog_III.Models;
using AutoMapper;

namespace _114032_Báez_Nicolás_Final_Prog_III.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //1)---GETS---
        CreateMap<Provincias, GetProvinciasDto>().ReverseMap();

        CreateMap<Tipos, GetTiposDto>().ReverseMap();

        CreateMap<Configuraciones, GetConfiguracionesDto>().ReverseMap();

        CreateMap<Sucursales, GetSucursalesDto>()
            .ForMember(dest => dest.ProvinciaNombre, opt => opt.MapFrom(src => src.IdProvinciaNavegation.Nombre))
            .ForMember(dest => dest.TipoNombre, opt => opt.MapFrom(src => src.IdTipoNavegation.Nombre))
            .ReverseMap();

        //2)---POST---
        CreateMap<Sucursales, PostSucursalDto>().ReverseMap();

        //3)---PUT---
        CreateMap<Sucursales, PutSucursalDto>().ReverseMap();
    }
}
