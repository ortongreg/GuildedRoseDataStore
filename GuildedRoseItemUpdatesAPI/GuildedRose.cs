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
                QualityControlledItem qcItem;
                Item item = Items[i];
                switch (item.Name)
                {
                    case "Aged Brie":
                        qcItem = new AgedBrie(item);
                        break;
                    default: 
                        qcItem = new QualityControlledItem(item);
                        break;
                }

                qcItem.UpdateItem();
            }
        }
    }
}
