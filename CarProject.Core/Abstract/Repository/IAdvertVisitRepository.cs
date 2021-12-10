using CarProject.Core.Entities;

namespace CarProject.Core.Abstract
{
    public interface IAdvertVisitRepository
    {
        Task<List<AdvertVisit>> GetAllVisits();
        Task AddVisit(string advertId, string ip);
    }
}
