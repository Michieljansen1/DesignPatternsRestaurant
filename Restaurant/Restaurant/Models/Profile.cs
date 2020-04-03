using System.Collections.ObjectModel;
using System.Diagnostics;
using Restaurant.Memento;
using Restaurant.Types;

namespace Restaurant.Models
{
    /// <summary>
    ///     User profile that keeps track of the menu for that specific profile
    /// </summary>
    internal class Profile
    {
        private int _id;

        /// <summary>
        ///     Constructor
        /// </summary>
        public Profile(int Id)
        {
            _id = Id;
            _menuItems = new ObservableCollection<IMenu<MainDishType>>();
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public ObservableCollection<IMenu<MainDishType>> ItemCollection
        {
            get { return _menuItems; }
        }

        private ObservableCollection<IMenu<MainDishType>> _menuItems { get; set; }

        /// <summary>
        ///     Adds item to the profile
        /// </summary>
        /// <param name="menu">MenuItem to add to the profile</param>
        public void AddItem(IMenu<MainDishType> menu)
        {
            _menuItems.Add(menu);
        }

        public ProfileMemento StoreInMemento()
        {
            return new ProfileMemento(Id, _menuItems);
        }

        public void LoadMemento(ProfileMemento memento)
        {
            _id = memento.ProfileId;
            _menuItems = memento.Items;
        }

        public void Print()
        {
            foreach (var menu in _menuItems)
            {
                Debug.WriteLine($"Menu: {menu.GetMenuType()}");
            }
        }
    }
}