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

        /// <summary>
        ///     Creates a new profile and sets it as active
        /// </summary>
        public void NewProfile()
        {
            _activeProfile = new Profile(_profileCaretaker.TotalProfiles);
            _profileCaretaker.AddOrUpdateProfile(_activeProfile.MakeMemento());
            //TODO: remove TEST
            AddProductToProfile(MenuType.BurgerMenu, DrinkType.Cola, SideType.Fries, MainDishType.BaconBurger, SizeType.Large);
        }

        public Profile ActiveProfile => _activeProfile;

        /// <summary>
        ///     Finalizes the current order
        /// </summary>
        public void Finish()
        {
            // ....

            _profileCaretaker.Clear();
        }

        public ProfileCaretaker ProfileCaretaker => _profileCaretaker;
    }
}