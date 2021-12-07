using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Combinations;
using Xunit;
using ApprovalTests.Reporters;
using GildedRoseKata;

namespace GildedRoseTests
{
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void Verify()
        {
            var names = new List<string>
            {
                "Aged Brie",
                "Backstage passes to a TAFKAL80ETC concert",
                "Sulfuras, Hand of Ragnaros",
                "Generic1",
            };
            var qualities = new List<int>
            {
                0,
                1,
                -1,
                50,
                49,
                80
            };

            var sellIns = new List<int>
            {
                0,
                6,
                5,
                -1,
                10,
                11,
                12,
                30,
            };
            CombinationApprovals.VerifyAllCombinations(DoUpdateQuality, names, qualities, sellIns);
        }
        
        private string DoUpdateQuality(string name, int quality, int sellIn)
        {
            var item = new Item() {Name = name, Quality = quality, SellIn = sellIn};
            var items = new List<Item>()
            {
                item,
            };
            var app = new GildedRose(items);
                
            app.UpdateQuality();

            return item.ToString();
        }
    }
}
