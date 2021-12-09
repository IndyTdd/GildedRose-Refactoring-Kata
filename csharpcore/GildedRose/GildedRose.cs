using System.Collections.Generic;

namespace GildedRoseKata
{
    public static class ItemNames
    {
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string AgedBrie = "Aged Brie";
        public const string Conjured = "Conjured";
    }

    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
                GetItemUpdater(item.Name).Update(item);
        }

        private static ItemUpdater GetItemUpdater(string name)
        {
            switch (name)
            {
                case ItemNames.AgedBrie:
                    return new AgedBrieItemUpdater();
                case ItemNames.BackstagePasses:
                    return new BackstagePassesItemUpdater();
                case ItemNames.Sulfuras:
                    return new SulfurasItemUpdater();
                case ItemNames.Conjured:
                    return new ConjuredItemUpdater();
                default:
                    return new GenericItemUpdater();
            }
        }
    }

    internal class ItemUpdater
    {
        public virtual void Update(Item item)
        {
            if (item.Quality > 0)
                item.Quality -= 1;

            item.SellIn -= 1;

            if (item.SellIn < 0 && item.Quality > 0)
                item.Quality -= 1;
        }
    }

    class ConjuredItemUpdater : ItemUpdater
    {
        public override void Update(Item item)
        {
            var originalQuality = item.Quality;
            base.Update(item);
            var baseUpdatedQuality = item.Quality;
            var delta = baseUpdatedQuality - originalQuality;
            var increasedDelta = delta * 2;
            var newQuality = originalQuality + increasedDelta;

            item.Quality = newQuality <= 0 ? 0 : newQuality;
        }
    }

    class AgedBrieItemUpdater : ItemUpdater
    {
        public override void Update(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
                    
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }
    }

    class BackstagePassesItemUpdater : ItemUpdater
    {
        public override void Update(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                            
                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }

                if (item.SellIn < 6)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
                            
            }
                        
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality -= item.Quality;
            }
        }
    }

    internal class GenericItemUpdater : ItemUpdater
    {
    }
    
    internal class SulfurasItemUpdater : ItemUpdater
    {
        public override void Update(Item item)
        { }
    }
}

