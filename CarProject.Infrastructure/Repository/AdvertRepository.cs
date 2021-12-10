using CarProject.Core.Abstract;
using CarProject.Core.Entities;
using CarProject.Core.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CarProject.Core.Repository
{
    public class AdvertRepository : GenericRepository<Advert> , IAdvertRepository
    {
        private readonly AppSettings _appSettings;
        public AdvertRepository(IConfiguration configuration, IOptions<AppSettings> appSettings, string tableName = "adverts") : base(configuration, appSettings, tableName)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<Advert> GetAdvert(int advertId)
        {
            return await GetAsync(advertId);
        }
        public async Task<List<PagedAdvert>> QueryAdverts(AdvertQueryParameters parameters)
        {

            using (var connection = CreateConnection())
            {
                //var query = connection.QueryBuilder($@"SELECT * , COUNT(*) OVER() AS totalCount FROM adverts WHERE 1=1");
                var sql = $@"SELECT * , COUNT(*) OVER() AS totalCount FROM {_tableName} WHERE 1=1";

                if (parameters != null)
                {
                    if (parameters.PriceLow.HasValue && parameters.PriceMax.HasValue && parameters.PriceLow > 0 && parameters.PriceMax > 0)
                    {
                        sql += ($" AND price BETWEEN {parameters.PriceLow} AND {parameters.PriceMax}");
                    }
                    else if (parameters.PriceLow.HasValue && !parameters.PriceMax.HasValue && parameters.PriceLow > 0)
                    {
                        sql += ($" AND price >= {parameters.PriceLow}");
                    }
                    else if (!parameters.PriceLow.HasValue && parameters.PriceMax.HasValue && parameters.PriceMax > 0)
                    {
                        sql += ($" AND price <= {parameters.PriceMax}");
                    }

                    if (parameters.CategoryId.HasValue && parameters.CategoryId > 0)
                    {
                        sql += ($" AND categoryid = {parameters.CategoryId}");
                    }

                    if (parameters.Fuel.HasValue)
                    {
                        sql += ($" AND fuel = '{parameters.Fuel.GetDisplayName()}'");
                    }

                    if (parameters.Gear.HasValue)
                    {
                        sql += ($" AND gear = '{parameters.Gear.GetDisplayName()}'");
                    }

                }

                int offset = Math.Max(0, (parameters.PageSize <= 0 ? _appSettings.DefaultPageSize : parameters.PageSize) * (parameters.Page - 1));

                //offset = parameters.Page <= 1 ? offset : offset+1;

                if (parameters.Sort.HasValue)
                {
                    sql += ($" ORDER BY {parameters.Sort.GetDisplayName()} {parameters.SortDirection.GetDisplayName()} LIMIT  {parameters.PageSize} OFFSET {offset}");
                }
                else
                {
                    sql += ($" LIMIT {parameters.PageSize} OFFSET {offset}");
                }

                var list = await connection.QueryAsync<PagedAdvert>(sql);
                return list.ToList();
            }
            

        }

    }
}
