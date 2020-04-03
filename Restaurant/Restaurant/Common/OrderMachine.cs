using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Popups;
using Restaurant.Builders;
using Restaurant.Factories;
using Restaurant.Memento;
using Restaurant.Models;
using Restaurant.Types;

namespace Restaurant.Common
{
    /// <summary>
    ///     Main core logic
    /// </summary>
    class OrderMachine
    {
        private Profile _activeProfile; // current profile that is ordering
        private ProfileCaretaker _profileCaretaker; // keeps track of the memento's

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="orderType"></param>
        public OrderMachine(string orderType = null)
        {
            _profileCaretaker = new ProfileCaretaker();
            NewProfile();
            NewProfile();
            NewProfile();
        }

        /// <summary>
        ///     Creates a new menu and adds it to the current active profile
        /// </summary>
        /// <param name="menuType">MenuType to create</param>
        /// <param name="drinkType">Type of drink to add</param>
        /// <param name="sideType">Type of menu side to add</param>
        /// <param name="mainDishType">Type of the main dish</param>
        /// <param name="sizeType">Size of the dish</param>
        public void AddProductToProfile(MenuType menuType, DrinkType drinkType, SideType sideType,
            MainDishType mainDishType, SizeType sizeType)
        {
            var menu = new DishFactory(
                    menuType,
                    drinkType,
                    sideType,
                    mainDishType,
                    sizeType)
                .CreateMenu();

            _activeProfile.AddItem(menu);
        }

        /// <summary>
        ///     Switches to the requested profile
        /// </summary>
        /// <param name="Id">Id of the profile to switch to</param>
        public void SwitchProfile(int Id)
        {
            var profileMemento = _activeProfile.MakeMemento();
            _profileCaretaker.AddOrUpdateProfile(profileMemento);

            var newProfile = _profileCaretaker.GetProfile(Id);
            _activeProfile.LoadMemento(newProfile);
        }

        public double TotalPrice
        {
            get {
                double total = 0;
                foreach (ProfileMemento profileCaretakerProfile in _profileCaretaker.Profiles)
                {
                    profileCaretakerProfile.Items.ForEach(item => total += item.GetTotalPrice());
                }

                return total;
            }
        }

        /// <summary>
        ///     Creates a new profile and sets it as active
        /// </summary>
        public void NewProfile()
        {
            _activeProfile = new Profile(_profileCaretaker.TotalProfiles);
            _profileCaretaker.AddOrUpdateProfile(_activeProfile.MakeMemento());
        }

        public Profile ActiveProfile => _activeProfile;

        /// <summary>
        ///     Finalizes the current order
        /// </summary>
        public void Finish(DeliveryType deliverType)
        {
            var director = new BillDirector();
            var list = new List<ProfileMemento>();
            list.AddRange(_profileCaretaker.Profiles);
            var deliverMessage = "";

            switch (deliverType)
            {
                case DeliveryType.TO_COUNTER:
                    deliverMessage = new Delivery().DeliveryType(deliverType);
                    director.SetBuilder(new AnalogBillBuilder());
                    director.BuildAnalogBill(System.DateTime.Now, list, TotalPrice, "Emmen", "Parallelweg 36A");
                    break;
                case DeliveryType.TO_TABLE_INSIDE:
                    deliverMessage = new DeliveryToTableDecorator(new Delivery()).DeliveryType(deliverType);
                    director.SetBuilder(new AnalogBillBuilder());
                    director.BuildAnalogBill(System.DateTime.Now, list, TotalPrice, "Emmen", "Parallelweg 36A");
                    break;
                case DeliveryType.TO_CAR_A:
                    deliverMessage = new DeliveryToCarDecorator(new Delivery()).DeliveryType(deliverType);
                    director.SetBuilder(new DigitalBillBuilder());
                    director.BuildDigitalBill(System.DateTime.Now, list, TotalPrice, "Emmen", "Parallelweg 36A", "info@kamermaat.nl");
                    break;
            }
            

            new MessageDialog($"{deliverMessage}\n{director.GetBill()}").ShowAsync();
            // _profileCaretaker.Clear();
        }

        public ProfileCaretaker ProfileCaretaker => _profileCaretaker;
    }
}