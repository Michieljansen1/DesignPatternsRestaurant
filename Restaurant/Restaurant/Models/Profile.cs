using System.Collections.ObjectModel;

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
        public Profile()
        {
            MenuItems = new ObservableCollection<Menu>();
        }

        public ObservableCollection<Menu> MenuItems { get; }

        /// <summary>
        ///     Adds item to the profile
        /// </summary>
        /// <param name="menu">MenuItem to add to the profile</param>
        public void AddItem(Menu menu)
        {
            MenuItems.Add(menu);
        }
    }
}