using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Attributes;
using Restaurant.Extensions;
using Restaurant.Models;
using Restaurant.Types;

namespace Restaurant.Factories
{
    public class WrapFactory : MenuFactory<WrapType>
    {
        /// <summary>
        /// The selected drink
        /// </summary>
        private readonly DrinkType _selectedDrink;

        /// <summary>
        /// The selected side dish
        /// </summary>
        private readonly SideType _selectedSide;

        /// <summary>
        /// The selected wrap main meal 
        /// </summary>
        private readonly WrapType _selectedMain;

        /// <summary>
        /// The selected menu size
        /// </summary>
        private readonly SizeType _selectedSize;

        /// <summary>
        /// The total price of all items
        /// </summary>
        private double _price;

        /// <summary>
        /// Intializes a new instance of <see cref="WrapFactory"/>
        /// </summary>
        /// <param name="drink">The <see cref="DrinkType"/> of the selected drink</param>
        /// <param name="side">The <see cref="SideType"/> of the selected side</param>
        /// <param name="main">The <see cref="WrapType"/> of the selected wrap</param>
        /// <param name="size">The <see cref="SizeType"/> of the selected menu size</param>
        public WrapFactory(DrinkType drink, SideType side, WrapType main, SizeType size)
        {
            _selectedDrink = drink;
            ApplyItemPrice(drink);

            _selectedSide = side;
            ApplyItemPrice(side);

            _selectedMain = main;
            ApplyItemPrice(main);

            _selectedSize = size;
        }

        // <inheritdoc />
        protected override IMenu<WrapType> ConstuctMenu()
        {
            return new Wrap(_selectedDrink, _selectedSide, _selectedMain, _selectedSize, _price);
        }

        /// <summary>
        /// Apply the price of a given product to the total
        /// </summary>
        /// <param name="value">The menu item to add</param>
        private void ApplyItemPrice(Enum value)
        {
            _price += value.GetCustomAttribute<MenuPriceAttribute>().Price;
        }
    }
}
