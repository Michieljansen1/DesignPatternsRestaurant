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


            var burgerMenu = new BurgerFactory(DrinkType.Cola, SideType.Fries, MainDishType.BaconBurger, SizeType.Large).CreateMenu();
            var junior = new JuniorFactory<MainDishType>(DrinkType.Sinas, SideType.Fries, MainDishType.JuniorBurger).CreateMenu();
            var wrap = new WrapFactory(DrinkType.Cola, SideType.Salad, MainDishType.ChickenWrap, SizeType.Large).CreateMenu();

            menus.Add(burgerMenu);

            menus.Add(junior);

            menus.Add(wrap);

            foreach (var menu in menus)
            {
                Debug.WriteLine("Maindish:" + menu.GetMainType());
                Debug.WriteLine("Price" + menu.GetTotalPrice());
            }
        }
    }
}
