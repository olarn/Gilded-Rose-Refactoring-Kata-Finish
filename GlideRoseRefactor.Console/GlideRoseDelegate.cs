using System;
using System.Collections.Generic;

namespace GlideRoseRefactor.Console
{
    public class GlideRoseDelegate
    {
        private int OneDay = 1;
        private int StandardQuality = 1;
        private int DoubleQuality = 2;
        private int TripleQuality = 3;
        private int TenDay = 10;
        private int FiveDay = 5;
        private int ZeroDay = 0;
        private int MaxQuality = 50;

        public void UpdateQuality(IList<Item> Items)
        {
            foreach (var item in Items)
            {
                if (IsSulfuras(item))
                    continue;

                ReduceSellIn(forItem: item);

                if (IsConjured(item))
                {
                    DecreaseQualityTwice(item);
                    continue;
                }

                if (IsBackstagePasses(item))
                {
                    IncreaseQualityForBackstagePasses(item);
                    continue;
                }

                if (IsAgedBrie(item))
                {
                    IncreaseQuality(item);
                    continue;
                }

                ReduceQuality(forItem: item);
            }

        }

        internal void ReduceSellIn(Item forItem)
        {
            var item = forItem;
            item.SellIn -= OneDay;
        }

        internal void ReduceQuality(Item forItem)
        {
            var item = forItem;
            item.Quality -= StandardQuality;
            if (item.Quality < 0)
                item.Quality = 0;
        }

        internal bool IsAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        internal void IncreaseQuality(Item item)
        {
            item.Quality += StandardQuality;
            if (item.Quality > MaxQuality)
                item.Quality = MaxQuality;
        }

        internal bool IsConjured(Item item)
        {
            return item.Name.StartsWith("Conjured");
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
            if (item.SellIn <= ZeroDay)
            {
                item.Quality = 0;
                return;
            }

            if (item.SellIn <= FiveDay)
            {
                item.Quality += TripleQuality;
                return;
            }

            if (item.SellIn <= TenDay)
            {
                item.Quality += DoubleQuality;
                return;
            }

            item.Quality += StandardQuality;
        }

        internal void DecreaseQualityTwice(Item item)
        {
            int TwiceStandardQuality = StandardQuality * 2;
            item.Quality -= TwiceStandardQuality;
            if (item.Quality == 0)
                item.Quality = 0;
        }

    }
}