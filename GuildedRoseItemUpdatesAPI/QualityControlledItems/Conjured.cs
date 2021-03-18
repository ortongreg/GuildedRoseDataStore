using System;

namespace GuildedRoseItemUpdatesAPI
{
    public class Conjured: QualityControlledItem
    {

        public Conjured(Item item): base(item) { }

        public override void UpdateItem(){

            item.Quality = Math.Max(0, item.Quality - 2);
            item.SellIn = item.SellIn - 1;
        }
    }
}
