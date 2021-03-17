using FluentAssertions;
using GuildedRoseBackend.Controllers;
using GuildedRoseBackend.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace GuildedRoseBackendTests
{
    public class ItemsControllerTests
    {
        ItemsController _controller;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<ItemContext> dbContextOptions = new DbContextOptionsBuilder<ItemContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;



            _controller = new ItemsController(new ItemContext(dbContextOptions), null);
        }

        [Test]
        public void GetSingleItemShouldReturnItemWithThatId()
        {
            var resultItem = _controller.GetQuery("1");
            resultItem.ID.Should().Be(1);
        }
    }
}