using GuildedRoseBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildedRoseBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {

        private readonly ILogger<ItemsController> _logger;

        private readonly Item[] _allItems = new Item[] {
                new Item { ID = 1, Name = "Foo", Quality = 10, SellIn = 11 },
                new Item { ID = 2, Name = "Bar", Quality = 12, SellIn = 13 },
            };

        public ItemsController(ILogger<ItemsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Item> Get() => _allItems;


        // GET items/1
        [HttpGet("{id}")]
        public Item GetQuery(string id) => _allItems.First(item => item.ID == Int32.Parse(id));
    }
}
