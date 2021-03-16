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

        private Item[] _allItems = new Item[] {
                new Item { id = 1, name = "Foo", quality = 10, sellIn = 11 },
                new Item { id = 2, name = "Bar", quality = 12, sellIn = 13 },
            };

        public ItemsController(ILogger<ItemsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Item> Get() => _allItems;


        // GET items/1
        [HttpGet("{id}")]
        public Item GetQuery(string id) => _allItems.First(item => item.id == Int32.Parse(id));
    }
}
