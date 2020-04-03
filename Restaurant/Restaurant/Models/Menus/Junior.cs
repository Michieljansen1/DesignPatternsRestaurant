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


        public Junior(DrinkType drink, SideType side, T main, double price)
        {
            _drink = drink;
            _side = side;
            _main = main;
            _price = price;
        }

        public MenuType GetMenuType()
        {
            throw new NotImplementedException();
        }

        public DrinkType GetDrinkType()
        {
            throw new NotImplementedException();
        }

        public SideType GetSideType()
        {
            throw new NotImplementedException();
        }

        public T GetMainType()
        {
            throw new NotImplementedException();
        }

        public SizeType GetSizeType()
        {
            throw new NotImplementedException();
        }

        public double GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
