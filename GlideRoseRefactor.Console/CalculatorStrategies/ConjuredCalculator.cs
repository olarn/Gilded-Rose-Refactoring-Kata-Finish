namespace GlideRoseRefactor.Console
{
    public class ConjuredCalculator : GlideRoseCalculator
    {
        protected override void CalculateQuality(Item item)
        {
            item.Quality = item.Quality - (ValueOf.StandardQuality * 2);
        }
    }
}