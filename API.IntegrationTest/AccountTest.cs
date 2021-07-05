using API.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API.IntegrationTest
{
    public class AccountTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public AccountTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }
        [Fact]
        public async Task TestLogin()
        {
            UserToLoginDTO appUser = new UserToLoginDTO();
            appUser.UserName = "user1";
            appUser.Password = "pass123";
            // Arrange
            var request = "/api/Account/Login";

            // Act
            var json = JsonConvert.SerializeObject(appUser);

            HttpContent payload = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(request, payload);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
