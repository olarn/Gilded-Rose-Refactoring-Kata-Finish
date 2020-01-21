namespace GlideRoseRefactor.Console
{
    public class GlideRoseDelegate
    {
        public void ReduceSellIn(Item forItem)
        {
            var item = forItem;
            item.SellIn -= 1;
        }

        public void ReduceQuality(Item forItem)
        {
            var item = forItem;
            item.Quality -= 1;
            if (item.Quality < 0)
                item.Quality = 0;
        }

        public bool IsAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        public void IncreaseQuality(Item item)
        {
            item.Quality += 1;
            if (item.Quality > 50)
                item.Quality = 50;
        }

        public bool IsSulfuras(Item item)
        {
            return item.Name.StartsWith("Sulfuras");
        }
    }
}