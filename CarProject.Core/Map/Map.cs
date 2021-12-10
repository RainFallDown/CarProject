using AutoMapper;
using CarProject.Core.Dto;
using CarProject.Core.Entities;

namespace CarProject.Core.Map
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Advert, AdvertDto>().ReverseMap();
            CreateMap<AdvertVisit, AdvertVisitDto>().ReverseMap();
            CreateMap<PagedAdvert, PagedAdvertDto>().ReverseMap();
        }
    }
}
