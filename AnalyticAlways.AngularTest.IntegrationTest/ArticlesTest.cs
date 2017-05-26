using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AnalyticAlways.AngularTest.IntegrationTest
{
    public class ArticlesTest : IClassFixture<TestFixture<AnalyticAlways.AngularTest2.Api.Startup>>
    {
        public ArticlesTest(TestFixture<AnalyticAlways.AngularTest2.Api.Startup> fixture)
        {
            Client = fixture.Client;
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task GetArticles()
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/articles");

            // Action
            var response = await Client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
