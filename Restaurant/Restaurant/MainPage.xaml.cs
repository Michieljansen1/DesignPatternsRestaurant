using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Restaurant.Common;
using Restaurant.Factories;
using Restaurant.Models;
using Restaurant.Types;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Restaurant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var orderMachine = new OrderMachine();
            DataContext = orderMachine;

            cmb_menuTypes.ItemsSource = Enum.GetValues(typeof(MenuType)).Cast<MenuType>();
            cmb_mainDish.ItemsSource = Enum.GetValues(typeof(MainDishType)).Cast<MainDishType>();
            cmb_drinkTypes.ItemsSource = Enum.GetValues(typeof(DrinkType)).Cast<DrinkType>();
            cmb_sideType.ItemsSource = Enum.GetValues(typeof(SideType)).Cast<SideType>();
            cmb_sizeType.ItemsSource = Enum.GetValues(typeof(SizeType)).Cast<SizeType>();

            List<IMenu> menus = new List<IMenu>();

            var menu1 = new DishFactory(
                MenuType.WrapMenu, 
                DrinkType.ColaZero,
                SideType.Fries, 
                MainDishType.ChickenWrap, 
                SizeType.Large)
                .CreateMenu();

            var menu2 = new DishFactory(
                    MenuType.BurgerMenu,
                    DrinkType.Cola,
                    SideType.Fries,
                    MainDishType.BaconBurger,
                    SizeType.Large)
                .CreateMenu();

            var menu3 = new DishFactory(
                    MenuType.JuniorMenu,
                    DrinkType.Cola,
                    SideType.Fries,
                    MainDishType.JuniorBurger,
                    SizeType.Large)
                .CreateMenu();


            menus.Add(menu1);
            menus.Add(menu2);
            menus.Add(menu3);



            foreach (var menu in menus)
            {
                Debug.WriteLine("Menu type:" + menu.GetMenuType());
                Debug.WriteLine("Price" + menu.GetTotalPrice());
            }
        }
    }
}
