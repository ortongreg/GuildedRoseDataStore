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
                switch (item.Name)
                {
                    case "Aged Brie":
                        new AgedBrie(item).UpdateItem();
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        new BackstagePass(item).UpdateItem();
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        new Sulfuras(item).UpdateItem();
                        break;
                    default: 
                        new QualityControlledItem(item).UpdateItem();
                        break;
                }

            }
        }
    }
}
