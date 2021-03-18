using GuildedRoseItemUpdatesAPI;
using NUnit.Framework;
using System.Collections.Generic;

namespace GuildedRoseItemUpdatesAPITests
{
    public class GuildedRoseTests
    {

        [Test]
        public void testQualityAndSellInForRegularItemDecreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(9, Items[0].Quality);
        }

        [Test]
        public void testQualityForRegularItemDegradesTwiceAsFast()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void testQualityForRegularItemIsNeverNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void testQualityAndInForAgesBrieIncreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(11, Items[0].Quality);
        }

        [Test]
        public void testAgedBrieQualityNeverAboveFifty()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void testBackstagePassIncreasesByTwoWithTenDaysRemaining()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(12, Items[0].Quality);
        }

        [Test]
        public void testBackStagePassesIncreasesByThreeWithFivesDaysRemaining()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(13, Items[0].Quality);
        }

        [Test]
        public void testBackStagePassesDropToZeroAfterConcert()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void testBackStagePassesQualityDoesntExceedFifty()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 49 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(7, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void testBackstagePassesIncreaseQualityByOneWhenSellInIsEleven()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(10, Items[0].SellIn);
            Assert.AreEqual(11, Items[0].Quality);
        }

        [Test]
        public void testBackstagePassesIncreaseQualityByTwoWhenSellInIsSix()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(5, Items[0].SellIn);
            Assert.AreEqual(12, Items[0].Quality);
        }

        [Test]
        public void testBackstagePassesIncreaseQualityByThreeWhenSellInIsOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(13, Items[0].Quality);
        }

        [Test]
        public void testSulfurasDoesNotUpdateSellInAndQualityIsEighty()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(10, Items[0].SellIn);
            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test]
        public void testConjuredDecreaseQualityByTwo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void testConjuredItemQualityNeverDropsBelowZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }
    }
}