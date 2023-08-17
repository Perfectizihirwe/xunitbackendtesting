using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit.Abstractions;
using APITesting;

namespace APITesting.Tests
{
    public class ProductsTests
    {
        private readonly ITestOutputHelper Console; 
        public ProductsTests(ITestOutputHelper outputHelper) {
            Console = outputHelper;
        }

        [Fact]
        public async void GetAllReturnsSuccess()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            var url = "/Products/";

            var response = await httpClient.GetAsync(url);
            
            Console.WriteLine($"Resonse is {response}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}