using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Types;

namespace Restaurant.Models.Menus
{
    public class Wrap : IMenu<WrapType>
    {
        private readonly DrinkType _drink;

        private readonly SideType _side;

        private readonly WrapType _main;

        private readonly SizeType _size;

        private readonly double _price;

        public Wrap(DrinkType drink, SideType side, WrapType main, SizeType size, double price)
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
        public WrapType GetMainType() => _main;

        // <inheritdoc />
        public SizeType GetSizeType() => _size;

        // <inheritdoc />
        public double GetTotalPrice() => _price;
    }
}
