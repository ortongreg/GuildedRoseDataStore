using FluentAssertions;
using GuildedRoseBackend;
using GuildedRoseBackend.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GuildedRoseBackendTests.EndToEndTests
{
    public class ExampleE2E
    {
        private TestServer _server;
        private HttpClient _client;

        [SetUp]
        public void setup()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Test]
        public async Task TestGetItems()
        {
            var response = await _client.GetAsync("/items");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            List<Item> responseItems = JsonConvert.DeserializeObject<List<Item>>(responseString);

            responseItems.Count.Should().Be(9);
            responseItems[0].ID.Should().Be(1);
        }
    }
}
