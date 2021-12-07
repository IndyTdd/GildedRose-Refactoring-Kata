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

                        break;
                    }
                    case "Backstage passes to a TAFKAL80ETC concert":
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

                        break;
                    }
                    case "Sulfuras, Hand of Ragnaros":
                        break;
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

    internal class GenericItemUpdater : ItemUpdater
    {
    }
}
