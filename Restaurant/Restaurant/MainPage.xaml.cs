using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

            var menu = new BurgerFactory(DrinkType.Cola, SideType.Fries, BurgerType.BaconBurger, SizeType.Large).CreateMenu();
            var junior = new JuniorFactory<BurgerType>(DrinkType.Sinas, SideType.Fries, BurgerType.JuniorBurger).CreateMenu();

            if (junior != null)
            {
                Debug.WriteLine($"Menu Type: {junior.GetMenuType()}");
                Debug.WriteLine($"Menu Price: {junior.GetTotalPrice()}");
                Debug.WriteLine($"Menu Price: {junior.GetSideType()}");
                Debug.WriteLine($"Menu Price: {junior.GetDrinkType()}");
            }
        }
    }
}
