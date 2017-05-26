using AnalyticAlways.AngularTest.Reads.Filters;
using AnalyticAlways.AngularTest.Reads.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnalyticAlways.AngularTest2.Api.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly ArticlesQueries _articlesQueries;

        public ArticlesController(ArticlesQueries articlesQueries)
        {
            _articlesQueries = articlesQueries;
        }

        // GET api/articles
        [HttpGet]
        public async Task<IActionResult> GetArticles([FromQuery] GetAllArticlesFilter filter)
        {
            var articles = await _articlesQueries.GetAllArticlesAsync(filter);

            return Ok(articles);
        }
    }
}
