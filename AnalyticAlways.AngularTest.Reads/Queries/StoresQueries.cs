using AnalyticAlways.AngularTest.Reads.Filters;
using AnalyticAlways.AngularTest.Reads.Infrastructure;
using AnalyticAlways.AngularTest.Reads.ViewModels;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticAlways.AngularTest.Reads.Queries
{
    public class StoresQueries
    {
        private readonly IAngularTestConnectionFactory _dbConnectionFactory;

        public StoresQueries(IAngularTestConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<PagedList<StoreViewModel>> GetAllStoresAsync(GetAllStoresFilter filter)
        {
            var countSql = new StringBuilder(@"
SELECT COUNT(Id)
FROM Stores
WHERE 1=1
");

            var mainSql = new StringBuilder(@"
SELECT Id, Name, City
FROM Stores
WHERE 1=1
");

            return await ExecuteGetStoresAsync(filter, countSql, mainSql);
        }

        private async Task<PagedList<StoreViewModel>> ExecuteGetStoresAsync(GetAllStoresFilter filter, StringBuilder countSql, StringBuilder mainSql)
        {
            if (!string.IsNullOrEmpty(filter.Id))
            {
                countSql.AppendLine("AND Id LIKE @IdFilter");
                mainSql.AppendLine("AND Id LIKE @IdFilter");
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                countSql.AppendLine("AND Name LIKE @NameFilter");
                mainSql.AppendLine("AND Name LIKE @NameFilter");
            }

            if (!string.IsNullOrEmpty(filter.City))
            {
                countSql.AppendLine("AND City LIKE @CityFilter");
                mainSql.AppendLine("AND City LIKE @CityFilter");
            }

            countSql.AppendLine("");
            mainSql.AppendLine("ORDER BY Id asc");

            mainSql.AppendLine(filter.PagingClause);

            var sql = countSql.ToString() + mainSql.ToString();

            using (var db = _dbConnectionFactory.CreateAngularTestConnection())
            using (var multi = await db.QueryMultipleAsync(sql, filter))
            {
                var pagingListViewModel = new PagedList<StoreViewModel>()
                {
                    TotalCount = (await multi.ReadAsync<int>()).Single(),
                    Items = (await multi.ReadAsync<StoreViewModel>()).ToList(),
                };

                return pagingListViewModel;
            }
        }
    }
}
