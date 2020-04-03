using System.Collections.Generic;
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
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="id">Profile Id</param>
        public Profile(int id)
        {
            Id = id;
            _menuItems = new ObservableCollection<IMenu>();
        }

        public int Id { get; set; }

        public ObservableCollection<IMenu> ItemCollection => _menuItems;

        private ObservableCollection<IMenu> _menuItems { get; set; }

        /// <summary>
        ///     Adds item to the profile
        /// </summary>
        /// <param name="menu">MenuItem to add to the profile</param>
        public void AddItem(IMenu menu)
        {
            _menuItems.Add(menu);
        }

        /// <summary>
        ///     Creates a new Memento object that can be saved with the ProfileCareTaker
        /// </summary>
        /// <returns>Memento object</returns>
        public ProfileMemento MakeMemento()
        {
            List<IMenu> list = new List<IMenu>();
            list.AddRange(_menuItems);
            return new ProfileMemento(Id, list);
        }

        /// <summary>
        ///     Loads the profile with the given memento object
        /// </summary>
        /// <param name="memento">Memento object to load</param>
        public void LoadMemento(ProfileMemento memento)
        {
            Id = memento.ProfileId;
            _menuItems.Clear();
            foreach (IMenu mementoItem in memento.Items)
            {
                _menuItems.Add(mementoItem);
            }
            Debug.WriteLine($"Loaded profile: {memento.ProfileId}");
        }
    }
}