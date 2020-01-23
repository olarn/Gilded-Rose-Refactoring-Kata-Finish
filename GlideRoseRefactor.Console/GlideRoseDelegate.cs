using System.Collections.Generic;

namespace GlideRoseRefactor.Console
{
    public class GlideRoseDelegate
    {
        public void UpdateQuality(IList<Item> Items)
        {
            foreach (var item in Items)
            {
                var calculator = GetCalculator(item);
                calculator.ReduceSellIn(item);
                calculator.CalculateQuality(item);
            }
        }

        private ItemType ItemTypeFor(Item item)
        {
            if (item.Name.StartsWith("Sulfuras")) return ItemType.Sulfuras;
            if (item.Name.StartsWith("Conjured")) return ItemType.Conjured;
            if (item.Name.StartsWith("Backstage passes")) return ItemType.BackstagePasses;
            if (item.Name == "Aged Brie") return ItemType.AgedBrie;
            return ItemType.Other;
        }

        private GlideRoseCalculator GetCalculator(Item item)
        {
            switch (ItemTypeFor(item))
            {
                case ItemType.Sulfuras: return new SulfurasCalculator();
                case ItemType.AgedBrie: return new AgedBrieCalculator();
                case ItemType.BackstagePasses: return new BackstagePassesCalculator();
                case ItemType.Conjured: return new ConjuredCalculator();
                default: return new GlideRoseCalculator();
            }
        }
    }
}