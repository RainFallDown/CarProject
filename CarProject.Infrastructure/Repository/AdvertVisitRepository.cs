using CarProject.Core.Abstract;
using CarProject.Core.Entities;
using CarProject.Core.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CarProject.Core.Repository
{
    public class AdvertVisitRepository : GenericRepository<AdvertVisit> , IAdvertVisitRepository
    {
        public AdvertVisitRepository(IConfiguration configuration, IOptions<AppSettings> appSettings, string tableName = "advertvisits") : base(configuration, appSettings, tableName)
        {
        }
        public async Task<List<AdvertVisit>> GetAllVisits()
        {
            var list = await GetAllAsync();
            return list.ToList();
        }
        public async Task AddVisit(string advertId, string ip)
        {
            AdvertVisit advertVisit = new()
            {
                AdvertId = Convert.ToInt64(advertId),
                IPAdress = ip,
                VisitDate = DateTime.Now
            };
            await InsertAsync(advertVisit);
        }
    }
}
