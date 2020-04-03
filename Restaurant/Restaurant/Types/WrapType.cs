using Restaurant.Attributes;

namespace Restaurant.Types
{
    public enum WrapType
    {
        [MenuPrice(1.50)]
        ChickenWrap,

        [MenuPriceAttribute(1)]
        [MenuRestrictionAttribute(MenuType.JuniorMenu)]
        JuniorWrap,

        [MenuPriceAttribute(1.50)]
        PorkWrap
    }
}
