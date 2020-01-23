namespace GlideRoseRefactor.Console
{
    public class BackstagePassesCalculator : GlideRoseCalculator
    {
        public override void CalculateQuality(Item item)
        {
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