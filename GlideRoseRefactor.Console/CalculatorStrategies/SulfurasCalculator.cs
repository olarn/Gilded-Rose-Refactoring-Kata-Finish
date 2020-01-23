namespace GlideRoseRefactor.Console
{
    public class SulfurasCalculator : GlideRoseCalculator
    {
        public override void CalculateQuality(Item item)
        {
            item.Quality = item.Quality;
        }
    }
}