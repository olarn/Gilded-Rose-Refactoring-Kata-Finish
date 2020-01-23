namespace GlideRoseRefactor.Console
{
    public class AgedBrieCalculator : GlideRoseCalculator
    {
        public override void CalculateQuality(Item item)
        {
            item.Quality += ValueOf.StandardQuality;
            SetMaxIfQualityGreaterThanMaximum(item);
        }
    }
}