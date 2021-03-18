namespace GuildedRoseItemUpdatesAPI
{
    public class RegularItem: QualityControlledItem
    {

        public RegularItem(Item item): base(item) { }

        public override void UpdateItem()
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
}
