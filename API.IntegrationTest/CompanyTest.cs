using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API.IntegrationTest
{
    public class CompanyTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public CompanyTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetCompanyAsync()
        {
            // Arrange
            var request = "/api/Company";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
