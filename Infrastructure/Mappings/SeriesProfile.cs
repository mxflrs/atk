using atk_api.Application.Dtos;
using atk_api.Application.Dtos.Requests;
using atk_api.Application.Dtos.Responses;
using atk_api.Domain.Entities;
using AutoMapper;

namespace atk_api.Infrastructure.Mappings;

public class SeriesProfile: Profile
{
    public SeriesProfile()
    {
        CreateMap<Series, SeriesDto>().ReverseMap();
        CreateMap<UpsertSeriesRequest, Series>().ReverseMap();
    }
}