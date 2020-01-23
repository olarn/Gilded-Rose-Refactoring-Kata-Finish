namespace GlideRoseRefactor.Console
{
    public class GlideRoseCalculator
    {
        public void Calculate(Item item)
        {
            ReduceSellIn(item);
            CalculateQuality(item);
            SetZeroQualityIfLowerMinQuality(item);
            SetMaxIfQualityGreaterThanMaximum(item);
        }

        private void ReduceSellIn(Item item)
        {
            item.SellIn -= ValueOf.OneDay;
            item.SellIn = item.SellIn < ValueOf.ZeroDay ? ValueOf.ZeroDay : item.SellIn;
        }

        private void SetZeroQualityIfLowerMinQuality(Item item)
        {
            item.Quality = item.Quality < ValueOf.MinQuality ? ValueOf.MinQuality : item.Quality;
        }

        protected virtual void SetMaxIfQualityGreaterThanMaximum(Item item)
        {
            item.Quality = item.Quality > ValueOf.MaxQuality ? ValueOf.MaxQuality : item.Quality;
        }

        protected virtual void CalculateQuality(Item item)
        {
            item.Quality -= ValueOf.StandardQuality;
        }
    }
}