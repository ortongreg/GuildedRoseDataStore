﻿namespace GuildedRoseItemUpdatesAPI
{
    public class BackstagePass: QualityControlledItem
    {

        public BackstagePass(Item item): base(item) { }

        public override void UpdateItem()
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
    }
}
