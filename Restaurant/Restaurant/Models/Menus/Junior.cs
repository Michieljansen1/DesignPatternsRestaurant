using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Types;

namespace Restaurant.Models.Menus
{
    public class Junior<T> : IMenu<T> where T : Enum
    {
        private readonly DrinkType _drink;

        private readonly SideType _side;

        private readonly T _main;

        private readonly double _price;


        public Junior(DrinkType drink, SideType side, T main, SizeType _selectedSize, double price)
        {
            _drink = drink;
            _side = side;
            _main = main;
            _price = price;
        }

        public MenuType GetMenuType() => MenuType.JuniorMenu;

        // <inheritdoc />
        public DrinkType GetDrinkType() => _drink;

        // <inheritdoc />
        public SideType GetSideType() => _side;

        // <inheritdoc />
        public T GetMainType() => _main;

        // <inheritdoc />
        public SizeType GetSizeType() => SizeType.Small;

        // <inheritdoc />
        public double GetTotalPrice() => _price;
    }
}
