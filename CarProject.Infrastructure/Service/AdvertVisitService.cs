using AutoMapper;
using CarProject.Core.Abstract;
using CarProject.Core.Abstract.Service;
using CarProject.Core.Dto;

namespace CarProject.Infrastructure.Service
{
    public class AdvertVisitService : IAdvertVisitService
    {
        private readonly IAdvertVisitRepository _advertVisitRepository;
        private readonly IMapper _mapper;
        public AdvertVisitService(IAdvertVisitRepository advertVisitRepository, IMapper mapper)
        {
            _mapper = mapper;
            _advertVisitRepository = advertVisitRepository;
        }
        public async Task<List<AdvertVisitDto>> GetAllVisits()
        {
            return _mapper.Map<List<AdvertVisitDto>>(await _advertVisitRepository.GetAllVisits());
        }
        public async Task AddVisit(string advertId, string ip)
        {
            await _advertVisitRepository.AddVisit(advertId, ip);
        }
    }
}
