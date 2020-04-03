using Restaurant.Attributes;

namespace Restaurant.Types
{
    public enum MainDishType
    {
        [MenuPrice(1)]
        CheeseBurger,

        [MenuPriceAttribute(1.50)]
        JuniorBurger,

        [MenuPriceAttribute(2.50)]
        BaconBurger,

        [MenuPrice(1.50)]
        ChickenWrap,

        [MenuPriceAttribute(1)]
        [MenuRestrictionAttribute(MenuType.JuniorMenu)]
        JuniorWrap,

        [MenuPriceAttribute(1.50)]
        PorkWrap
    }
}
