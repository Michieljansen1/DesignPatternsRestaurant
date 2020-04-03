using Restaurant.Types;

namespace Restaurant.Models.Menus
{
    public class Wrap : IMenu
    {
        private readonly DrinkType _drink;

        private readonly MainDishType _main;

        private readonly double _price;

        private readonly SideType _side;

        private readonly SizeType _size;

        public Wrap(DrinkType drink, SideType side, MainDishType main, SizeType size, double price)
        {
            _drink = drink;
            _side = side;
            _main = main;
            _size = size;
            _price = price;
        }

        // <inheritdoc />
        public MenuType GetMenuType() => MenuType.WrapMenu;

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