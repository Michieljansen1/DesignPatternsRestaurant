using Restaurant.Memento;
using Restaurant.Models;
using Restaurant.Types;

namespace Restaurant.Common
{
    /// <summary>
    /// 
    /// </summary>
    class OrderMachine
    {
        private ProfileCaretaker _profileCaretaker;
        private Profile _activeProfile;

        public OrderMachine(string orderType = null)
        {
            
        }

        public void AddProductToProfile(DrinkType drinkType, SideType sideType, MainDishType mainDishType, SizeType sizeType)
        {

            // _activeProfile.AddItem();
        }

        public void SwitchProfile(int Id)
        {
            var profileMemento = _activeProfile.MakeMemento();
            _profileCaretaker.AddOrUpdateProfile(profileMemento);

            var newProfile = _profileCaretaker.GetProfile(Id);
            _activeProfile.LoadMemento(newProfile);
        }

        public void NewProfile()
        {
            _activeProfile = new Profile(_profileCaretaker.TotalProfiles);
        }

        public void Finish()
        {

        }
    }
}
