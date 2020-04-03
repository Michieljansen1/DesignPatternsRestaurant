﻿using System;
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
    public class BurgerFactory : MenuFactory<BurgerType>
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
        /// The selected burger main dish
        /// </summary>
        private readonly BurgerType _selectedMain;

        /// <summary>
        /// The selected menu size
        /// </summary>
        private readonly SizeType _selectedSize;

        /// <summary>
        /// The total price of all items
        /// </summary>
        private double _price;

        /// <summary>
        /// Intializes a new instance of <see cref="BurgerFactory"/>
        /// </summary>
        /// <param name="drink">The <see cref="DrinkType"/> of the selected drink</param>
        /// <param name="side">The <see cref="SideType"/> of the selected side</param>
        /// <param name="main">The <see cref="BurgerType"/> of the selected burger</param>
        /// <param name="size">The <see cref="SizeType"/> of the selected menu size</param>
        public BurgerFactory(DrinkType drink, SideType side, BurgerType main, SizeType size)
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
        protected override IMenu<BurgerType> ConstuctMenu()
        {
            return new Burger(_selectedDrink, _selectedSide, _selectedMain, _selectedSize, _price);
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