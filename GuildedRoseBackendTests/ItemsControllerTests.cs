using FluentAssertions;
using GuildedRoseBackend.Controllers;
using NUnit.Framework;

namespace GuildedRoseBackendTests
{
    public class ItemsControllerTests
    {
        ItemsController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new ItemsController(null);
        }

        [Test]
        public void GetSingleItemShouldReturnItemWithThatId()
        {
            var resultItem = _controller.GetQuery("1");
            resultItem.id.Should().Be(1);
        }
    }
}