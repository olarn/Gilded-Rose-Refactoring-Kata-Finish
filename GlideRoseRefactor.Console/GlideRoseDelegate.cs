using System.Collections.Generic;

namespace GlideRoseRefactor.Console
{
    public class GlideRoseDelegate
    {
        public void UpdateQuality(IList<Item> Items)
        {
            foreach (var item in Items)
                GetCalculatorBy(item).Calculate(item);
        }

        private GlideRoseCalculator GetCalculatorBy(Item item)
        {
            if (item.Name.StartsWith("Sulfuras")) return new SulfurasCalculator();
            if (item.Name.StartsWith("Conjured")) return new ConjuredCalculator();
            if (item.Name.StartsWith("Backstage passes")) return new BackstagePassesCalculator();
            if (item.Name == "Aged Brie") return new AgedBrieCalculator();
            return new GlideRoseCalculator();
        }
    }
}