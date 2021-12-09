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
            return name switch
            {
                ItemNames.AgedBrie => new AgedBrieItemUpdater(),
                ItemNames.BackstagePasses => new BackstagePassesItemUpdater(),
                ItemNames.Sulfuras => new SulfurasItemUpdater(),
                ItemNames.Conjured => new ConjuredItemUpdater(),
                _ => new GenericItemUpdater()
            };
        }
    }
}

