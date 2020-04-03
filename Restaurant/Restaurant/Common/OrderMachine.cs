using System;
using System.Collections.Generic;
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
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="orderType"></param>
        public OrderMachine(string orderType = null)
        {
            ProfileCaretaker = new ProfileCaretaker();
            NewProfile();
        }

        public double TotalPrice
        {
            get {
                double total = 0;
                foreach (ProfileMemento profileCaretakerProfile in ProfileCaretaker.Profiles)
                {
                    profileCaretakerProfile.Items.ForEach(item => total += item.GetTotalPrice());
                }

                return total;
            }
        }

        public Profile ActiveProfile { get; private set; }

        public ProfileCaretaker ProfileCaretaker { get; }

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

            ActiveProfile.AddItem(menu);
        }

        /// <summary>
        ///     Switches to the requested profile
        /// </summary>
        /// <param name="Id">Id of the profile to switch to</param>
        public void SwitchProfile(int Id)
        {
            var profileMemento = ActiveProfile.MakeMemento();
            ProfileCaretaker.AddOrUpdateProfile(profileMemento);

            var newProfile = ProfileCaretaker.GetProfile(Id);
            ActiveProfile.LoadMemento(newProfile);
        }

        /// <summary>
        ///     Creates a new profile and sets it as active
        /// </summary>
        public void NewProfile()
        {
            if (ActiveProfile == null)
            {
                ActiveProfile = new Profile(ProfileCaretaker.TotalProfiles);
            } else
            {
                ProfileCaretaker.AddOrUpdateProfile(ActiveProfile.MakeMemento());
            }

            ActiveProfile.ItemCollection.Clear();
            ActiveProfile.Id = ProfileCaretaker.TotalProfiles;
            ProfileCaretaker.AddOrUpdateProfile(ActiveProfile.MakeMemento());
        }

        /// <summary>
        ///     Finalizes the current order
        /// </summary>
        public void Finish(DeliveryType deliverType)
        {
            SwitchProfile(0);
            var director = new BillDirector();
            var list = new List<ProfileMemento>();
            list.AddRange(ProfileCaretaker.Profiles);
            var deliverMessage = "";

            switch (deliverType)
            {
                case DeliveryType.TO_COUNTER:
                    deliverMessage = new Delivery().DeliveryType(deliverType);
                    director.SetBuilder(new AnalogBillBuilder());
                    director.BuildAnalogBill(DateTime.Now, list, TotalPrice, "Emmen", "Parallelweg 36A");
                    break;
                case DeliveryType.TO_TABLE_INSIDE:
                    deliverMessage = new DeliveryToTableDecorator(new Delivery()).DeliveryType(deliverType);
                    director.SetBuilder(new AnalogBillBuilder());
                    director.BuildAnalogBill(DateTime.Now, list, TotalPrice, "Emmen", "Parallelweg 36A");
                    break;
                case DeliveryType.TO_CAR_A:
                    deliverMessage = new DeliveryToCarDecorator(new Delivery()).DeliveryType(deliverType);
                    director.SetBuilder(new DigitalBillBuilder());
                    director.BuildDigitalBill(DateTime.Now, list, TotalPrice, "Emmen", "Parallelweg 36A",
                        "info@kamermaat.nl");
                    break;
            }


            new MessageDialog($"{deliverMessage}\n{director.GetBill()}").ShowAsync();
            ProfileCaretaker.Clear();
        }
    }
}