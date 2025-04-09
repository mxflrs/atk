using atk_api.Application.Dtos;
using atk_api.Domain.Entities;
using AutoMapper;

namespace atk_api.Infrastructure.Mappings;

public class MaterialsProfile : Profile
{
    public MaterialsProfile()
    {
        CreateMap<MaterialDto, Material>().ReverseMap();
        CreateMap<UpsertMaterialDto, Material>().ReverseMap();
    }
}