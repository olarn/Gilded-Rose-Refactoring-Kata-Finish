namespace GlideRoseRefactor.Console
{
    public class AgedBrieCalculator : GlideRoseCalculator
    {
        // ged Brie" actually increases in Quality the older it gets
        protected override void CalculateQuality(Item item)
        {
            item.Quality += ValueOf.StandardQuality;
        }
    }
}