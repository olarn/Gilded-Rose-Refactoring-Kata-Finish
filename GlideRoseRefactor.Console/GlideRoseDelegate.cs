using System.Collections.Generic;

namespace GlideRoseRefactor.Console
{
    public class GlideRoseDelegate
    {
        public void UpdateQuality(IList<Item> Items)
        {
            foreach (var item in Items)
                UpdateQualityByTypeFor(item);
        }

        void UpdateQualityByTypeFor(Item item)
        {
            switch (ItemTypeFor(item))
            {
                case ItemType.Sulfuras:
                    ReduceSellIn(item);
                    break;
                case ItemType.AgedBrie:
                    IncreaseQuality(item);
                    break;
                case ItemType.BackstagePasses:
                    IncreaseQualityForBackstagePasses(item);
                    break;
                case ItemType.Conjured:
                    DecreaseQualityTwice(item);
                    break;
                default:
                    DecreaseQuality(item: item);
                    break;
            }
        }

        ItemType ItemTypeFor(Item item)
        {
            if (item.Name.StartsWith("Sulfuras")) return ItemType.Sulfuras;
            if (item.Name.StartsWith("Conjured")) return ItemType.Conjured;
            if (item.Name.StartsWith("Backstage passes")) return ItemType.BackstagePasses;
            if (item.Name == "Aged Brie") return ItemType.AgedBrie;
            return ItemType.Other;
        }

        void SetZeroQualityIfLowerMinQuality(Item item)
        {
            if (item.Quality < MinQuality)
                item.Quality = MinQuality;
        }

        void SetMaxIfQualityGreaterThanMaximum(Item item)
        {
            if (item.Quality > MaxQuality)
                item.Quality = MaxQuality;
        }

        void SetZeroSellInIfLowerThanZero(Item item)
        {
            if (item.SellIn < ZeroDay)
                item.SellIn = ZeroDay;
        }

        void ReduceSellIn(Item item)
        {
            item.SellIn -= OneDay;
            SetZeroSellInIfLowerThanZero(item);
        }

        void DecreaseQuality(Item item)
        {
            ReduceSellIn(item);
            item.Quality -= StandardQuality;
            SetZeroQualityIfLowerMinQuality(item);
        }

        void DecreaseQualityTwice(Item item)
        {
            ReduceSellIn(item);
            item.Quality = item.Quality - (StandardQuality * 2);
            SetZeroQualityIfLowerMinQuality(item);
        }

        void IncreaseQuality(Item item)
        {
            ReduceSellIn(item);
            item.Quality += StandardQuality;
            SetMaxIfQualityGreaterThanMaximum(item);
        }

        void IncreaseQualityForBackstagePasses(Item item)
        {
            ReduceSellIn(item);

            item.Quality += StandardQuality;
            if (item.SellIn <= TenDay)
                item.Quality += StandardQuality;
            if (item.SellIn <= FiveDay)
                item.Quality += StandardQuality;
            if (item.SellIn <= ZeroDay)
                item.Quality = MinQuality;

            SetMaxIfQualityGreaterThanMaximum(item);
        }

        const int MinQuality = 0;
        const int OneDay = 1;
        const int StandardQuality = 1;
        const int TenDay = 10;
        const int FiveDay = 5;
        const int ZeroDay = 0;
        const int MaxQuality = 50;
    }
}