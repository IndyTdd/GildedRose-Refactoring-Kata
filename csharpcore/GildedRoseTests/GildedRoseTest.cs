using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        private List<Item> _items;
        private GildedRose _app;
        private Item _conjured;
        private Item _generic;
        
        public GildedRoseTest()
        {
            _conjured = new Item {Name = "Conjured", Quality = 10, SellIn = 10};
            _generic = new Item {Name = "Generic", Quality = 10, SellIn = 10};
            
            _items = new List<Item>()
            {
                _conjured,
                _generic,
            };
            _app = new GildedRose(_items);
        }

        [Fact]
        public void It_Decreases_The_Quality_Of_A_NonExpired_ConjuredItem_2x_Faster_Than_Normal_Item()
        {
            SetItem(_conjured, quality: 10, sellIn: 10);
            SetItem(_generic, quality: 10, sellIn: 10);

            _app.UpdateQuality();

            Assert.Equal(9, _generic.Quality);
            Assert.True(8 == _conjured.Quality, "Conjured items should decrease in quality twice as fast");
        }
        
        [Fact]
        public void It_Decreases_The_Quality_Of_An_Expired_ConjuredItem_2x_Faster_Than_Normal_Item()
        {
            SetItem(_conjured, quality: 10, sellIn: 0);
            SetItem(_generic, quality: 10, sellIn: 0);

            _app.UpdateQuality();

            Assert.Equal(8, _generic.Quality);
            Assert.True(6 == _conjured.Quality, "Expired Conjured items should decrease in quality twice as fast");
        }
        
        [Fact]
        public void It_Never_Decreases_ConjuredItem_Quality_Below_0()
        {
            SetItem(_conjured, quality: 0, sellIn: 4);

            _app.UpdateQuality();
            
            Assert.True(0 == _conjured.Quality, "Conjured Item quality should never decrease below zero.");
        }

        private void SetItem(Item item, int quality, int sellIn)
        {
            item.Quality = quality;
            item.SellIn = sellIn;
        }
    }
}
