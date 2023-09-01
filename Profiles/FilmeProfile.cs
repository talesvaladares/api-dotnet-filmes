using AutoMapper;
using filmesApi.Models;
using filmesApi.DTO;

namespace filmesApi.Profiles;

public class FilmeProfile : Profile
{

    public FilmeProfile() {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDTO>();
    }
}
