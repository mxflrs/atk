using atk_api.Application.Dtos;
using atk_api.Application.Dtos.Requests;
using atk_api.Application.Dtos.Responses;
using atk_api.Domain.Entities;
using AutoMapper;

namespace atk_api.Infrastructure.Mappings;

public class MaterialsProfile : Profile
{
    public MaterialsProfile()
    {
        CreateMap<MaterialDto, Material>().ReverseMap();
        CreateMap<UpsertMaterialRequest, Material>().ReverseMap();
    }
}