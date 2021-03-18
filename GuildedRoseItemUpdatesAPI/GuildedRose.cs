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
                QualityControlledItem qcItem;
                switch (item.Name)
                {
                    case "Aged Brie":
                        qcItem = new AgedBrie(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        qcItem = new BackstagePass(item);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        qcItem = new Sulfuras(item);
                        break;
                    default:
                        qcItem = new RegularItem(item);
                        break;
                }
                qcItem.UpdateItem();

            }
        }
    }
}
