using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Types;

namespace Restaurant.Models.Menus
{
    public class Junior: IMenu
    {
        private readonly DrinkType _drink;

        private readonly MainDishType _main;

        private readonly SideType _side;

        private readonly SizeType _size;

        private readonly double _price;



        public Junior(DrinkType drink, SideType side, SizeType size, double price)
        {
            _drink = drink;
            _side = side;
            _size = size;
            _price = price;
        }

        public MenuType GetMenuType() => MenuType.JuniorMenu;

        // <inheritdoc />
        public MainDishType GetMainType() => _main;

        // <inheritdoc />
        public DrinkType GetDrinkType() => _drink;

        // <inheritdoc />
        public SideType GetSideType() => _side;


        // <inheritdoc />
        public SizeType GetSizeType() => SizeType.Small;

        // <inheritdoc />
        public double GetTotalPrice() => _price;
    }
}
