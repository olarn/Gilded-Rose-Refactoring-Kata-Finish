using System;

namespace GlideRoseRefactor.Console
{
    public class GlideRoseDelegate
    {
        internal void ReduceSellIn(Item forItem)
        {
            var item = forItem;
            item.SellIn -= 1;
        }

        internal void ReduceQuality(Item forItem)
        {
            var item = forItem;
            item.Quality -= 1;
            if (item.Quality < 0)
                item.Quality = 0;
        }

        internal bool IsAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        internal void IncreaseQuality(Item item)
        {
            item.Quality += 1;
            if (item.Quality > 50)
                item.Quality = 50;
        }

        internal bool IsSulfuras(Item item)
        {
            return item.Name.StartsWith("Sulfuras");
        }

        internal bool IsBackstagePasses(Item item)
        {
            return item.Name.StartsWith("Backstage passes");
        }

        internal void IncreaseQualityForBackstagePasses(Item item)
        {
            item.Quality += 1;
        }
    }
}