using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Text;
using Windows.UI.Xaml;
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

        private OrderMachine _orderMachine;

        public MainPage()
        {
            this.InitializeComponent();

            _orderMachine = new OrderMachine();
            DataContext = _orderMachine;

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

        private void Btn_addMenu_OnClick(object sender, RoutedEventArgs e)
        {
            _orderMachine.AddProductToProfile(
                (MenuType)cmb_menuTypes.SelectionBoxItem,
                (DrinkType)cmb_drinkTypes.SelectionBoxItem,
                (SideType)cmb_sideType.SelectionBoxItem,
                (MainDishType)cmb_mainDish.SelectionBoxItem,
                (SizeType)cmb_sizeType.SelectionBoxItem);
        }

        private void Cmb_profile_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var profile = (Profile)cmb_profile.SelectionBoxItem;
            

            if (profile != null)
            {
                _orderMachine.SwitchProfile(profile.Id);
            }
        }
    }
}
