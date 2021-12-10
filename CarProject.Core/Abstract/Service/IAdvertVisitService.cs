using CarProject.Core.Dto;

namespace CarProject.Core.Abstract.Service
{
    public interface IAdvertVisitService
    {
        Task<List<AdvertVisitDto>> GetAllVisits();
        Task AddVisit(string advertId, string ip);
    }
}
