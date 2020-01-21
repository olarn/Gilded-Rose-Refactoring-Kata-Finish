using System.Collections.Generic;

namespace GlideRoseRefactor.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item> {
                    new Item { Name = "+5 Dexterity Vest",          SellIn = 10, Quality = 20},
                    new Item { Name = "Aged Brie",                  SellIn = 2,  Quality = 0},
                    new Item { Name = "Elixir of the Mongoose",     SellIn = 5,  Quality = 7},
                    new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0,  Quality = 80},
                    new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                    new Item { Name = "Conjured Mana Cake",          SellIn = 3,  Quality = 6}
                }
            };
            app.UpdateQuality();
            System.Console.Read();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                ReduceSellIn(forItem: item);
                if (IsAgedBrie(item))
                {
                    IncreaseQuality(item);
                    continue;
                }
                ReduceQuality(forItem: item);
            }
        }

        private void ReduceSellIn(Item forItem)
        {
            var item = forItem;
            item.SellIn -= 1;
        }

        private void ReduceQuality(Item forItem)
        {
            var item = forItem;
            item.Quality -= 1;
            if (item.Quality < 0)
                item.Quality = 0;
        }

        private bool IsAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private void IncreaseQuality(Item item)
        {
            item.Quality += 1;
            if (item.Quality > 50)
                item.Quality = 50;
        }
    }
}
