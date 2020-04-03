using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Restaurant.Factories;
using Restaurant.Models;
using Restaurant.Models.Menus;
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

            List<IMenu<MainDishType>> menus = new List<IMenu<MainDishType>>();

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
                Debug.WriteLine("Food:" + menu.GetMainType());
                Debug.WriteLine("Price" + menu.GetTotalPrice());
            }
        }
    }
}
