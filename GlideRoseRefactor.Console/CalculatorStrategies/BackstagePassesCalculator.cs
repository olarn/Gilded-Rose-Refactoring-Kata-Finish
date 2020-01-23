namespace GlideRoseRefactor.Console
{
    public class BackstagePassesCalculator : GlideRoseCalculator
    {
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