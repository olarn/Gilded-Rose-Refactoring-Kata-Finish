namespace GlideRoseRefactor.Console
{
    public class ConjuredCalculator : GlideRoseCalculator
    {
        public override void CalculateQuality(Item item)
        {
            item.Quality = item.Quality - (ValueOf.StandardQuality * 2);
            SetZeroQualityIfLowerMinQuality(item);
        }
    }
}