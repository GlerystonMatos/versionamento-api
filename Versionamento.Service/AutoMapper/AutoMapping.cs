using AutoMapper;
using Versionamento.Domain.Dto;
using Versionamento.Domain.Entities;

namespace Versionamento.Service.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Animal, AnimalDto>()
                .ReverseMap();

            CreateMap<Usuario, UsuarioDto>()
                .ReverseMap();
        }
    }
}