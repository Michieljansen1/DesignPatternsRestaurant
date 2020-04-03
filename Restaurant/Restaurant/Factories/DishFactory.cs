using System;
using Restaurant.Attributes;
using Restaurant.Extensions;
using Restaurant.Models;
using Restaurant.Models.Menus;
using Restaurant.Types;

namespace Restaurant.Factories
{
    public class DishFactory : MenuFactory
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
        private readonly MainDishType _selectedMain;

        /// <summary>
        /// The selected menu size
        /// </summary>
        private readonly SizeType _selectedSize;

        /// <summary>
        /// The selected menu type
        /// </summary>
        private readonly MenuType _menuType;

        /// <summary>
        /// The total price of all items
        /// </summary>
        private double _price;


        public DishFactory(MenuType menu, DrinkType drink, SideType side, MainDishType main, SizeType size)
        {
            _menuType = menu;

            _selectedDrink = drink;
            ApplyItemPrice(drink);

            _selectedSide = side;
            ApplyItemPrice(side);

            _selectedMain = main;
            ApplyItemPrice(main);


            _selectedSize = size;
        }

        protected override IMenu ConstuctMenu()
        {
            switch (_menuType)
            {
                case MenuType.BurgerMenu:
                    return new Burger(_selectedDrink, _selectedSide, _selectedMain, _selectedSize, _price);

                case MenuType.WrapMenu:
                    return new Wrap(_selectedDrink, _selectedSide, _selectedMain, _selectedSize, _price);

                case MenuType.JuniorMenu:
                    // return new Junior(_selectedDrink, _selectedSide, _selectedMain, _selectedSize, _price);
                    return new Junior(_selectedDrink, _selectedSide, _selectedSize, _price);

            }

            return null;
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