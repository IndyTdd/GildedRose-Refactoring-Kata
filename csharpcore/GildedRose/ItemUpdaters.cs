namespace GildedRoseKata
{
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
                item.Quality += 1;

            item.SellIn -= 1;

            if (item.SellIn < 0)
                if (item.Quality < 50)
                    item.Quality += 1;
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
                    if (item.Quality < 50)
                        item.Quality += 1;

                if (item.SellIn < 6)
                    if (item.Quality < 50)
                        item.Quality += 1;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
                item.Quality -= item.Quality;
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