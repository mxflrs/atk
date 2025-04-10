using atk_api.Application.Dtos.Requests;
using atk_api.Application.Dtos.Responses;
using atk_api.Domain.Entities;
using AutoMapper;

namespace atk_api.Infrastructure.Mappings;

public class LaborTypeProfile: Profile
{
    public LaborTypeProfile()
    {
        CreateMap<LaborTypeDto, LaborType>().ReverseMap();
        CreateMap<UpsertLaborTypeRequest, LaborType>().ReverseMap();
    }
}