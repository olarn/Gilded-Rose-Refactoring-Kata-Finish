using System;
using System.Collections.Generic;

namespace GlideRoseRefactor.Console
{
    public class GlideRoseDelegate
    {
        const int MinQuality = 0;
        const int OneDay = 1;
        const int StandardQuality = 1;
        const int TenDay = 10;
        const int FiveDay = 5;
        const int ZeroDay = 0;
        const int MaxQuality = 50;

        public void UpdateQuality(IList<Item> Items)
        {
            foreach (var item in Items)
            {
                ReduceSellIn(forItem: item);
                SetZeroSellInIfLowerThanZero(item);

                var itemType = ItemTypeFor(item);
                if (itemType == ItemType.Sulfuras)
                    continue;

                switch (itemType)
                {
                    case ItemType.AgedBrie:
                        IncreaseQuality(item);
                        SetMaxIfQualityGreaterThanMaximum(item);
                        break;
                    case ItemType.BackstagePasses:
                        IncreaseQualityForBackstagePasses(item);
                        SetMaxIfQualityGreaterThanMaximum(item);
                        break;
                    case ItemType.Conjured:
                        DecreaseQualityTwice(item);
                        SetZeroQualityIfLowerMinQuality(item);
                        break;
                    default:
                        DecreaseQuality(forItem: item);
                        SetZeroQualityIfLowerMinQuality(item);
                        break;
                }
            }
        }

        ItemType ItemTypeFor(Item item)
        {
            if (IsSulfuras(item)) return ItemType.Sulfuras;
            if (IsConjured(item)) return ItemType.Conjured;
            if (IsBackstagePasses(item)) return ItemType.BackstagePasses;
            if (IsAgedBrie(item)) return ItemType.AgedBrie;
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

        bool IsAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        bool IsConjured(Item item)
        {
            return item.Name.StartsWith("Conjured");
        }

        bool IsSulfuras(Item item)
        {
            return item.Name.StartsWith("Sulfuras");
        }

        bool IsBackstagePasses(Item item)
        {
            return item.Name.StartsWith("Backstage passes");
        }

        void ReduceSellIn(Item forItem)
        {
            forItem.SellIn -= OneDay;
        }

        void DecreaseQuality(Item forItem)
        {
            forItem.Quality -= StandardQuality;
        }

        void DecreaseQualityTwice(Item item)
        {
            item.Quality = item.Quality - (StandardQuality * 2);
        }

        void IncreaseQuality(Item item)
        {
            item.Quality += StandardQuality;
        }

        void IncreaseQualityForBackstagePasses(Item item)
        {
            item.Quality += StandardQuality;

            if (item.SellIn <= TenDay)
                item.Quality += StandardQuality;

            if (item.SellIn <= FiveDay)
                item.Quality += StandardQuality;

            if (item.SellIn <= ZeroDay)
                item.Quality = MinQuality;
        }
    }
}