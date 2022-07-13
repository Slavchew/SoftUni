namespace TestingApp.Web.Tests
{
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class SettingPageTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> server;

        public SettingPageTests(WebApplicationFactory<Startup> factory)
        {
            this.server = factory;
        }

        [Fact]
        public async void SettingsPageShouldCoutainsSettingsHeading()
        {
            var client = this.server.CreateClient();

            var response = await client.GetAsync("/Settings");

            response.EnsureSuccessStatusCode();

            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("<h1>Settings</h1>", html);
        }
    }
}
