using System.Collections.Generic;
using System.Collections.ObjectModel;
using Restaurant.Memento;
using Restaurant.Types;

namespace Restaurant.Models
{
    /// <summary>
    ///     User profile that keeps track of the menu for that specific profile
    /// </summary>
    internal class Profile
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="id">Profile Id</param>
        public Profile(int id)
        {
            Id = id;
            _menuItems = new ObservableCollection<IMenu<MainDishType>>();
        }

        public int Id { get; set; }

        public ObservableCollection<IMenu<MainDishType>> ItemCollection => _menuItems;

        private ObservableCollection<IMenu<MainDishType>> _menuItems { get; set; }

        /// <summary>
        ///     Adds item to the profile
        /// </summary>
        /// <param name="menu">MenuItem to add to the profile</param>
        public void AddItem(IMenu<MainDishType> menu)
        {
            _menuItems.Add(menu);
        }

        /// <summary>
        ///     Creates a new Memento object that can be saved with the ProfileCareTaker
        /// </summary>
        /// <returns>Memento object</returns>
        public ProfileMemento MakeMemento()
        {
            return new ProfileMemento(Id, _menuItems);
        }

        /// <summary>
        ///     Loads the profile with the given memento object
        /// </summary>
        /// <param name="memento">Memento object to load</param>
        public void LoadMemento(ProfileMemento memento)
        {
            Id = memento.ProfileId;
            _menuItems = memento.Items;
        }
    }
}