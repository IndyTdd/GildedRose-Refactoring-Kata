namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString()
        {
            return $"Item {{ {nameof(Name)}: {Name}, {nameof(SellIn)}: {SellIn}, {nameof(Quality)}: {Quality} }}";
        }
    }
}
