using MongoUsuarios.Dtos;
using AutoMapper;
using MongoUsuarios.Models;

namespace MongoUsuarios.Mapping
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
