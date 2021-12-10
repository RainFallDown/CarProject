using CarProject.Core.Dto;
using CarProject.Core.Model;

namespace CarProject.Core.Abstract.Service
{
    public interface IAdvertService
    {
        Task<AdvertDto> GetAdvert(int advertId);
        Task<QueryAdvertDto> QueryAdverts(AdvertQueryParameters parameters);
    }
}
