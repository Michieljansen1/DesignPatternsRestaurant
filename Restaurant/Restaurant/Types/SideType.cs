using Restaurant.Attributes;

namespace Restaurant.Types
{
    public enum SideType
    {
        [MenuPrice(1.50)] Fries,

        [MenuPriceAttribute(0.75)] Salad
    }
}