using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildedRoseItemUpdatesAPI
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                UpdateItem(item);
            }
        }

        private static void UpdateItem(Item item)
        {
            if(item.Name == "Aged Brie")
            {
                UpdateAgedBrie(item);
            }else if(item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpdateBackstagePass(item);
            }else if(item.Name == "Sulfuras, Hand of Ragnaros")
            {
                UpdateSulfuras(item);
            }

            else
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }

                item.SellIn = item.SellIn - 1;

                if (item.SellIn < 0)
                {
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }

            }
        }

        private static void UpdateSulfuras(Item item)
        {
        }

        private static void UpdateBackstagePass(Item item)
        {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                        
                }
                

                item.SellIn = item.SellIn - 1;

                if (item.SellIn < 0)
                {
                    item.Quality = item.Quality - item.Quality;   
                }
        }

        private static void UpdateAgedBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
            

            item.SellIn = item.SellIn - 1;
            

            if (item.SellIn < 0)
            {
                
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
                
            }
        }
    }
}
