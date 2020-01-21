using System;
using Xunit;
using GlideRoseRefactor.Console;
using System.Collections.Generic;
using System.Linq;

namespace GlideRoseRefactor.Tests
{
    public class GlideRoseTest
    {
        [Fact]
        public void GlideRoseItemsTest()
        {
            // Arrange

            var app = new Program();
            app.Items = new List<Item> {
                new Item { Name = "+5 Dexterity Vest",          SellIn = 10, Quality = 20},
                new Item { Name = "Aged Brie",                  SellIn = 2,  Quality = 0},
                new Item { Name = "Elixir of the Mongoose",     SellIn = 5,  Quality = 7},
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0,  Quality = 80},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                // new Item { Name = "Conjured Mana Cake",          SellIn = 3,  Quality = 6}
            };

            var expectedItems = new List<Item> {
                new Item { Name = "+5 Dexterity Vest",          SellIn = 9, Quality = 19},
                new Item { Name = "Aged Brie",                  SellIn = 1,  Quality = 1},
                new Item { Name = "Elixir of the Mongoose",     SellIn = 4,  Quality = 6},
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0,  Quality = 80},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 21},
                // new Item { Name = "Conjured Mana Cake",          SellIn = 2,  Quality = 3}
            };

            // Act

            app.UpdateQuality();

            // Assert

            for (int i = 0; i < app.Items.Count; i++)
            {
                var expectedEachItem = expectedItems[i];
                var actualItem = app.Items[i];
                Assert.Equal(expectedEachItem.SellIn, actualItem.SellIn);
                Assert.Equal(expectedEachItem.Quality, actualItem.Quality);
            }
        }
    }
}
