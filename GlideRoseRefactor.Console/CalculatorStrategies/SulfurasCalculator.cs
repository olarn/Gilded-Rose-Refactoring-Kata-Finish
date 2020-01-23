namespace GlideRoseRefactor.Console
{
    /// Note: "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    public class SulfurasCalculator : GlideRoseCalculator
    {
        // This rule never apply to Sulfuras
        protected override void SetMaxIfQualityGreaterThanMaximum(Item item)
        {
            item.Quality = item.Quality;
        }

        // This rule never apply to Sulfuras
        protected override void CalculateQuality(Item item)
        {
            item.Quality = item.Quality;
        }
    }
}