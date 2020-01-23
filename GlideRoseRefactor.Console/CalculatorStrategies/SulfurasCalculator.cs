namespace GlideRoseRefactor.Console
{
    public class SulfurasCalculator : GlideRoseCalculator
    {
        protected override void SetMaxIfQualityGreaterThanMaximum(Item item)
        {
            item.Quality = item.Quality;
        }

        protected override void CalculateQuality(Item item)
        {
            item.Quality = item.Quality;
        }
    }
}