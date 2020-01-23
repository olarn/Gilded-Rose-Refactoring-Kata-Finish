namespace GlideRoseRefactor.Console
{
    public class BackstagePassesCalculator : GlideRoseCalculator
    {
        /* Requirement :-
           "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; 
            Quality increases by 2 when there are 10 days 
                  or less and by 3 when there are 5 days 
                  or less but Quality drops to 0 after the concert
        */
        protected override void CalculateQuality(Item item)
        {
            item.Quality += ValueOf.StandardQuality;
            if (item.SellIn <= ValueOf.TenDay)
                item.Quality += ValueOf.StandardQuality;
            if (item.SellIn <= ValueOf.FiveDay)
                item.Quality += ValueOf.StandardQuality;
            if (item.SellIn <= ValueOf.ZeroDay)
                item.Quality = ValueOf.MinQuality;
        }
    }
}