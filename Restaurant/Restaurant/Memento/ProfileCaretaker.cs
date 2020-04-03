using System;
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
        /// <summary>
        ///     Constructor
        /// </summary>
        public ProfileCaretaker()
        {
            Profiles = new ObservableCollection<ProfileMemento>();
        }

        public int TotalProfiles => Profiles.Count;

        public ObservableCollection<ProfileMemento> Profiles { get; }

        /// <summary>
        ///     Adds / saves a new profile to the system
        /// </summary>
        /// <param name="profile">Profile to add</param>
        public void AddOrUpdateProfile(ProfileMemento profile)
        {
            var existingProfile = Profiles.FirstOrDefault(p => p.ProfileId == profile.ProfileId);

            // If there no profile with the given ID we create a new one otherwise we replace the menu items
            if (existingProfile == null)
            {
                Profiles.Add(profile);
                Console.WriteLine("Creating new profile");
            } else
            {
                existingProfile.Items = profile.Items;
                Console.WriteLine("Updating existing profile");
            }
        }

        /// <summary>
        ///     Tries to find the requested profile having ID x and returns it
        /// </summary>
        /// <param name="Id">Id of the profile</param>
        /// <returns></returns>
        public ProfileMemento GetProfile(int Id)
        {
            return Profiles.First(p => p.ProfileId == Id);
        }

        /// <summary>
        ///     Removes all the profiles except the first. The first profile only gets cleared.
        /// </summary>
        public void Clear()
        {
            var firstItem = Profiles[0];
            firstItem.Items.Clear();

            Profiles.Clear(); // Clearing the item list of the first profile
            Profiles.Add(firstItem);
        }
    }
}