using Restaurant.Types;

namespace Restaurant.Models.Menus
{
    public class Burger : IMenu
    {
        private readonly DrinkType _drink;

        private readonly SideType _side;

        private readonly MainDishType _main;

        private readonly SizeType _size;

        private readonly double _price;

        public Burger(DrinkType drink, SideType side, MainDishType main, SizeType size, double price)
        {
            _drink = drink;
            _side = side;
            _main = main;
            _size = size;
            _price = price;
        }

        // <inheritdoc />
        public MenuType GetMenuType() => MenuType.BurgerMenu;

        // <inheritdoc />
        public DrinkType GetDrinkType() => _drink;

        // <inheritdoc />
        public SideType GetSideType() => _side;

        // <inheritdoc />
        public MainDishType GetMainType() => _main;

        // <inheritdoc />
        public SizeType GetSizeType() => _size;

        // <inheritdoc />
        public double GetTotalPrice() => _price;
    }
}
