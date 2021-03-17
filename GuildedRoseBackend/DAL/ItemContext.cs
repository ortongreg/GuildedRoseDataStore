using GuildedRoseBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GuildedRoseBackend.DAL
{
    public class ItemContext : DbContext
    {

        public ItemContext(DbContextOptions<ItemContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }


        public void AddItem()
        {
            Items.Add(new Item { Name = "Foo", Quality = 14, SellIn = 13 });
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { ID = 1, Name = "5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { ID = 2, Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { ID = 3, Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { ID = 4, Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { ID = 5, Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item { ID = 6, Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new Item { ID = 7, Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 },
                new Item { ID = 8, Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 },
                new Item { ID = 9, Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            );
        }
    }
}
