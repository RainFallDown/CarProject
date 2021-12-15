using AutoMapper;
using CarProject.Core.Abstract;
using CarProject.Core.Abstract.Service;
using CarProject.Core.Dto;
using CarProject.Core.Model;

namespace CarProject.Infrastructure.Service
{
    public class AdvertService : IAdvertService
    {
        private IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;
        public AdvertService(IAdvertRepository advertRepository, IMapper mapper)
        {
            _mapper = mapper;
            _advertRepository = advertRepository;
        }
        public async Task<AdvertDto> GetAdvert(int advertId)
        {
            return _mapper.Map<AdvertDto>(await _advertRepository.GetAdvert(advertId));
        }
        public async Task<QueryAdvertDto> QueryAdverts(AdvertQueryParameters parameters)
        {
            var adverts = await _advertRepository.QueryAdverts(parameters);
            
            if(adverts != null && adverts.Count > 0)
            {
                return new QueryAdvertDto()
                {
                    Adverts = _mapper.Map<List<PagedAdvertDto>>(adverts),
                    Total = adverts.FirstOrDefault().TotalCount,
                    Page = parameters.Page == 0 ? 1 : parameters.Page,
                };
            }
            return new QueryAdvertDto();
        }
    }
}
