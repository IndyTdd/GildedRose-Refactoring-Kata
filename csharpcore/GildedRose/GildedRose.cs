using System.Collections.Generic;

namespace GildedRoseKata
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
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                    {
                        new AgedBrieItemUpdater().Update(item);
                        break;
                    }
                    case "Backstage passes to a TAFKAL80ETC concert":
                    {
                        new BackstagePassesItemUpdater().Update(item);
                        break;
                    }
                    case "Sulfuras, Hand of Ragnaros":
                    {
                        new SulfurasItemUpdater().Update(item);
                        break;
                    }
                    default:
                    {
                        new GenericItemUpdater().Update(item);
                        break;
                    }
                }
            }
        }
    }

    internal class ItemUpdater
    {
        public virtual void Update(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality -= 1;
                }
            }
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

