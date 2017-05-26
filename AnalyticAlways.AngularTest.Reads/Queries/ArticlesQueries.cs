using AnalyticAlways.AngularTest.Reads.Filters;
using AnalyticAlways.AngularTest.Reads.Infrastructure;
using AnalyticAlways.AngularTest.Reads.ViewModels;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticAlways.AngularTest.Reads.Queries
{
    public class ArticlesQueries
    {
        private readonly IAngularTestConnectionFactory _dbConnectionFactory;

        public ArticlesQueries(IAngularTestConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<PagedList<ArticleViewModel>> GetAllArticlesAsync(GetAllArticlesFilter filter)
        {
            var countSql = new StringBuilder(@"
SELECT COUNT(Id)
FROM Articles
WHERE 1=1
");

            var mainSql = new StringBuilder(@"
SELECT Id, Description, Price
FROM Articles
WHERE 1=1
");

            return await ExecuteGetArticlesAsync(filter, countSql, mainSql);
        }

        private async Task<PagedList<ArticleViewModel>> ExecuteGetArticlesAsync(GetAllArticlesFilter filter, StringBuilder countSql, StringBuilder mainSql)
        {
            if (!string.IsNullOrEmpty(filter.Id))
            {
                countSql.AppendLine("AND Id LIKE @IdFilter");
                mainSql.AppendLine("AND Id LIKE @IdFilter");
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                countSql.AppendLine("AND Description LIKE @DescriptionFilter");
                mainSql.AppendLine("AND Description LIKE @DescriptionFilter");
            }

            if (!string.IsNullOrEmpty(filter.Price))
            {
                countSql.AppendLine("AND Price LIKE @PriceFilter");
                mainSql.AppendLine("AND Price LIKE @PriceFilter");
            }

            countSql.AppendLine("");
            mainSql.AppendLine("ORDER BY Id asc");

            mainSql.AppendLine(filter.PagingClause);

            var sql = countSql.ToString() + mainSql.ToString();

            using (var db = _dbConnectionFactory.CreateAngularTestConnection())
            using (var multi = await db.QueryMultipleAsync(sql, filter))
            {
                var pagingListViewModel = new PagedList<ArticleViewModel>()
                {
                    TotalCount = (await multi.ReadAsync<int>()).Single(),
                    Items = (await multi.ReadAsync<ArticleViewModel>()).ToList(),
                };

                return pagingListViewModel;
            }
        }
    }
}
