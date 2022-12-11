using AutoMapper;
using Entities.Models;
using SharedHelpers.DataTransferObjects;

namespace CardGameApi.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Card,CardDto>();
        CreateMap<CardHistory, CardHistoryDto>();
        CreateMap<CardHistoryDto, CardHistory>();
        CreateMap<HandForCreationDto,CardHistory>();
    }
}
