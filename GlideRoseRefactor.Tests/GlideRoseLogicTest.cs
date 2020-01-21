using System.Collections.Generic;
using GlideRoseRefactor.Console;
using Xunit;

namespace GlideRoseRefactor.Tests
{
    public class GlideRoseLogicTest
    {
        private Program app = new Program();

        [Fact]
        public void OnceTheSellByDateHasPassed_QualityDegradesTwiceAsFast()
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
        public void TheQualityOfAnItemIsNeverNegative()
        {
            //Given
            app.Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 1, Quality = 0 } };

            //When
            app.UpdateQuality();

            //Then
            Assert.Equal(0, app.Items[0].Quality);
        }

    }
}