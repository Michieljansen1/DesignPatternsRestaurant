using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Attributes;
using Restaurant.Extensions;
using Restaurant.Models;
using Restaurant.Models.Menus;
using Restaurant.Types;

namespace Restaurant.Factories
{
    public class JuniorFactory<T> : MenuFactory<T> where T : Enum
    {
        /// <summary>
        /// The <see cref="DrinkType"/>
        /// </summary>
        private readonly DrinkType _selectedDrink;

        /// <summary>
        /// The selected side dish
        /// </summary>
        private readonly SideType _selectedSide;

        /// <summary>
        /// The selected main dish
        /// </summary>
        private readonly T _selectedMain;

        /// <summary>
        /// The total price of all items
        /// </summary>
        private double _price;

        /// <summary>
        /// Intializes a new instance of <see cref="JuniorFactory{T}"/>
        /// NOTE: Junior meals are always <see cref="SizeType.Small"/>
        /// </summary>
        /// <param name="drink">The <see cref="DrinkType"/> of the selected drink</param>
        /// <param name="side">The <see cref="SideType"/> of the selected side</param>
        /// <param name="main">The <see cref="T"/> of the selected junior main</param>
        public JuniorFactory(DrinkType drink, SideType side, T main)
        {
            _selectedDrink = drink;
            ApplyItemPrice(drink);

            _selectedSide = side;
            ApplyItemPrice(side);

            _selectedMain = main;
            ApplyItemPrice(main);
        }

        // <inheritdoc />
        protected override IMenu<T> ConstuctMenu()
        {
            return new Junior<T>(_selectedDrink, _selectedSide, _selectedMain, _price);
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
