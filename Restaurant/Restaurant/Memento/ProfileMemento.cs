﻿using System.Collections.ObjectModel;
using Restaurant.Models;
using Restaurant.Types;

namespace Restaurant.Memento
{
    /// <summary>
    ///     Loads and saves the menu for a given profile
    /// </summary>
    internal class ProfileMemento
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="profileId">Id that makes the profile unique</param>
        /// <param name="items">List of menu items to save</param>
        public ProfileMemento(int profileId, ObservableCollection<IMenu<MainDishType>> items)
        {
            ProfileId = profileId;
            Items = items;
        }

        public int ProfileId { get; }
        public ObservableCollection<IMenu<MainDishType>> Items { get; set; }
    }
}