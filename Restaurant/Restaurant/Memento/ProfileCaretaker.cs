﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Restaurant.Memento
{
    /// <summary>
    ///     This class manages the saving process of the memento objects. It can load and save memento object and overwrites
    ///     them
    ///     in case the memento already exist.
    /// </summary>
    internal class ProfileCaretaker
    {
        private readonly ObservableCollection<ProfileMemento> _profiles; // List of memento's to save

        /// <summary>
        ///     Constructor
        /// </summary>
        public ProfileCaretaker()
        {
            _profiles = new ObservableCollection<ProfileMemento>();
        }

        /// <summary>
        ///     Adds / saves a new profile to the system
        /// </summary>
        /// <param name="profile">Profile to add</param>
        public void AddOrUpdateProfile(ProfileMemento profile)
        {
            var existingProfile = _profiles.FirstOrDefault(p => p.ProfileId == profile.ProfileId);

            // If there no profile with the given ID we create a new one otherwise we replace the menu items
            if (existingProfile == null)
                _profiles.Add(profile);
            else
                existingProfile.Items = profile.Items;
        }

        /// <summary>
        ///     Tries to find the requested profile having ID x and returns it
        /// </summary>
        /// <param name="Id">Id of the profile</param>
        /// <returns></returns>
        public ProfileMemento GetProfile(int Id)
        {
            return _profiles.First(p => p.ProfileId == Id);
        }

        public int TotalProfiles => _profiles.Count;

        public ObservableCollection<ProfileMemento> Profiles => _profiles;

        /// <summary>
        ///     Clears all the profiles from the system
        /// </summary>
        public void Clear()
        {
            _profiles.Clear();
        }
    }
}