using CarProject.Core.Entities;
using CarProject.Core.Model;

namespace CarProject.Core.Abstract
{
    public interface IAdvertRepository
    {
        Task<Advert> GetAdvert(int deviceId);
        Task<List<PagedAdvert>> QueryAdverts(AdvertQueryParameters parameters);
    }
}
