namespace GlideRoseRefactor.Console
{
    public class GlideRoseCalculator
    {
        public void ReduceSellIn(Item item)
        {
            item.SellIn -= ValueOf.OneDay;
            SetZeroSellInIfLowerThanZero(item);
        }

        protected void SetZeroSellInIfLowerThanZero(Item item)
        {
            if (item.SellIn < ValueOf.ZeroDay)
                item.SellIn = ValueOf.ZeroDay;
        }

        protected void SetMaxIfQualityGreaterThanMaximum(Item item)
        {
            if (item.Quality > ValueOf.MaxQuality)
                item.Quality = ValueOf.MaxQuality;
        }

        protected void SetZeroQualityIfLowerMinQuality(Item item)
        {
            if (item.Quality < ValueOf.MinQuality)
                item.Quality = ValueOf.MinQuality;
        }

        public virtual void CalculateQuality(Item item)
        {
            item.Quality -= ValueOf.StandardQuality;
            SetZeroQualityIfLowerMinQuality(item);
        }
    }
}