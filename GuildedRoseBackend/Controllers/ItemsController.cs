using GuildedRoseBackend.DAL;
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
        private readonly ItemContext _itemContext;
        private readonly ILogger<ItemsController> _logger;

        public ItemsController(ItemContext itemContext, ILogger<ItemsController> logger)
        {    
            itemContext.Database.EnsureCreated();
            
            _itemContext = itemContext;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Item> Get() => _itemContext.Items;


        // GET items/1
        [HttpGet("item/{id}")]
        public Item GetQuery(string id) => _itemContext.Items.First(item => item.ID == Int32.Parse(id));

        [HttpGet("add")]
        public void AddItem() => _itemContext.AddItem();
    }
}
