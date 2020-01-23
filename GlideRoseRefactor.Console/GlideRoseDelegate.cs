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
            if (item.Quality < ValueOf.MinQuality)
                item.Quality = ValueOf.MinQuality;
        }

        void SetMaxIfQualityGreaterThanMaximum(Item item)
        {
            if (item.Quality > ValueOf.MaxQuality)
                item.Quality = ValueOf.MaxQuality;
        }

        void SetZeroSellInIfLowerThanZero(Item item)
        {
            if (item.SellIn < ValueOf.ZeroDay)
                item.SellIn = ValueOf.ZeroDay;
        }

        void ReduceSellIn(Item item)
        {
            item.SellIn -= ValueOf.OneDay;
            SetZeroSellInIfLowerThanZero(item);
        }

        void DecreaseQuality(Item item)
        {
            ReduceSellIn(item);
            item.Quality -= ValueOf.StandardQuality;
            SetZeroQualityIfLowerMinQuality(item);
        }

        void DecreaseQualityTwice(Item item)
        {
            ReduceSellIn(item);
            item.Quality = item.Quality - (ValueOf.StandardQuality * 2);
            SetZeroQualityIfLowerMinQuality(item);
        }

        void IncreaseQuality(Item item)
        {
            ReduceSellIn(item);
            item.Quality += ValueOf.StandardQuality;
            SetMaxIfQualityGreaterThanMaximum(item);
        }

        void IncreaseQualityForBackstagePasses(Item item)
        {
            ReduceSellIn(item);

            item.Quality += ValueOf.StandardQuality;
            if (item.SellIn <= ValueOf.TenDay)
                item.Quality += ValueOf.StandardQuality;
            if (item.SellIn <= ValueOf.FiveDay)
                item.Quality += ValueOf.StandardQuality;
            if (item.SellIn <= ValueOf.ZeroDay)
                item.Quality = ValueOf.MinQuality;

            SetMaxIfQualityGreaterThanMaximum(item);
        }
    }
}