using AnalyticAlways.AngularTest.Reads.ViewModels;
using AnalyticAlways.AngularTest2.IntegrationTest;
using FluentAssertions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AnalyticAlways.AngularTest2.IntergrationTest
{
    public class StoresTest : IClassFixture<TestFixture<AnalyticAlways.AngularTest2.Api.Startup>>
    {
        public StoresTest(TestFixture<AnalyticAlways.AngularTest2.Api.Startup> fixture)
        {
            Client = fixture.Client;
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task GetStores()
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/stores");

            // Action
            var response = await Client.SendAsync(request);

            var values = await response.Content.ReadAsAsync<PagedList<StoreViewModel>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            values.TotalCount.Should().Be(50);
            values.Items.Count().Should().Be(10);
        }
    }
}
