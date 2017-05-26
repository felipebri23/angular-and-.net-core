using AnalyticAlways.AngularTest.Reads.ViewModels;
using AnalyticAlways.AngularTest2.IntergrationTest;
using FluentAssertions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AnalyticAlways.AngularTest2.IntegrationTest
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
            var request = new HttpRequestMessage(new HttpMethod("GET"), "api/articles");

            // Action
            var response = await Client.SendAsync(request);

            var values = await response.Content.ReadAsAsync<PagedList<ArticleViewModel>>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            values.TotalCount.Should().Be(100);
            values.Items.Count().Should().Be(10);
        }
    }
}
