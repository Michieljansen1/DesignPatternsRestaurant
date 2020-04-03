using Restaurant.Attributes;

namespace Restaurant.Types
{
    public enum DrinkType
    {
        [MenuPriceAttribute(1.50)]
        Sinas,

        [MenuPriceAttribute(1.50)]
        Cola,

        [MenuPriceAttribute(1.50)]
        ColaZero
    }
}
