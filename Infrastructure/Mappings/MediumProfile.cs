using atk_api.Application.Dtos;
using atk_api.Domain.Entities;
using AutoMapper;

namespace atk_api.Infrastructure.Mappings;

public class MediumProfile: Profile
{
    public MediumProfile()
    {
        CreateMap<Medium, MediumDto>().ReverseMap();
        CreateMap<Medium, UpsertMediumDto>().ReverseMap();
    }
}