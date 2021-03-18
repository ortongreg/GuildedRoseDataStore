using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildedRoseItemUpdatesAPI
{
    public class AgedBrie: QualityControlledItem
    {

        public AgedBrie(Item item): base(item) { }

        public void UpdateItem(){
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
