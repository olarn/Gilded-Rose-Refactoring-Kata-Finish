namespace GlideRoseRefactor.Console
{
    public class AgedBrieCalculator : GlideRoseCalculator
    {
        protected override void CalculateQuality(Item item)
        {
            item.Quality += ValueOf.StandardQuality;
        }
    }
}