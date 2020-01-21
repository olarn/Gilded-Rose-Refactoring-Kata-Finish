using System.Collections.Generic;
using GlideRoseRefactor.Console;
using Xunit;

namespace GlideRoseRefactor.Tests
{
    public class GlideRoseLogicTest
    {
        private Program app = new Program();

        [Fact]
        public void Once_the_sell_by_Date_has_passed_Quality_degrades_twice_as_fast()
        {
            //Given
            app.Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 1, Quality = 1 } };

            //When
            app.UpdateQuality();

            //Then
            Assert.Equal(0, app.Items[0].SellIn);
            Assert.Equal(0, app.Items[0].Quality);
        }

        [Fact]
        public void The_quality_of_an_item_is_never_negative()
        {
            //Given
            app.Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 1, Quality = 0 } };

            //When
            app.UpdateQuality();

            //Then
            Assert.Equal(0, app.Items[0].Quality);
        }

        [Fact]
        public void AgedBrie_actually_increases_in_Quality_the_older_it_gets()
        {
            //Given
            app.Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };

            //When
            app.UpdateQuality();

            //Then
            Assert.Equal(1, app.Items[0].Quality);
        }

        [Fact]
        public void The_Quality_of_an_item_is_never_more_than_50()
        {
            //Given
            app.Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 50 } };

            //When
            app.UpdateQuality();

            //Then
            Assert.Equal(50, app.Items[0].Quality);
        }

        [Fact]
        public void Backstage_passes_increases_Quality_increase_1_when_sellIn_moreThan_10()
        {
            //Given
            app.Items = new List<Item> { new Item { Name = "Backstage passes a X concert", SellIn = 12, Quality = 10 } };

            //When
            app.UpdateQuality();

            //Then
            Assert.Equal(11, app.Items[0].SellIn);
            Assert.Equal(11, app.Items[0].Quality);
        }

    }
}