using Restaurant.Attributes;

namespace Restaurant.Types
{
    public enum BurgerType
    {
        [MenuPrice(1)]
        CheeseBurger,

        [MenuPriceAttribute(1.50)]
        JuniorBurger,

        [MenuPriceAttribute(2.50)]
        BaconBurger
    }
}
