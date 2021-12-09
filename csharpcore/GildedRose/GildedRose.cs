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
                GetItemUpdater(item.Name).Update(item);
        }

        private static ItemUpdater GetItemUpdater(string name)
        {
            if (name == ItemNames.AgedBrie)
                return new AgedBrieItemUpdater();
            if (name == ItemNames.BackstagePasses)
                return new BackstagePassesItemUpdater();
            if (name == ItemNames.Sulfuras)
                return new SulfurasItemUpdater();
            if (name == ItemNames.Conjured)
                return new ConjuredItemUpdater();
            return new GenericItemUpdater();
        }
    }
}

