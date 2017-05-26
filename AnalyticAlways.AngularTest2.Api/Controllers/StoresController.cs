using AnalyticAlways.AngularTest.Reads.Filters;
using AnalyticAlways.AngularTest.Reads.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnalyticAlways.AngularTest2.Api.Controllers
{
    [Route("api/[controller]")]
    public class StoresController : Controller
    {
        private readonly StoresQueries _storesQueries;

        public StoresController(StoresQueries storesQueries)
        {
            _storesQueries = storesQueries;
        }

        // GET api/stores
        [HttpGet]
        public async Task<IActionResult> GetStores([FromQuery] GetAllStoresFilter filter)
        {
            var stores = await _storesQueries.GetAllStoresAsync(filter);

            return Ok(stores);
        }
    }
}
