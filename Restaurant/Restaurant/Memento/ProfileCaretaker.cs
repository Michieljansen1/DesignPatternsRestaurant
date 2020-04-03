using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Memento
{
    internal class ProfileCaretaker
    {
        private readonly List<ProfileMemento> _profiles;

        public ProfileCaretaker()
        {
            _profiles = new List<ProfileMemento>();
        }

        public void AddProfile(ProfileMemento profile)
        {
            var existingProfile = _profiles.FirstOrDefault(p => p.ProfileId == profile.ProfileId);

            // If there no profile with the given ID we create a new one otherwise we replace the menu items
            if (existingProfile == null)
                _profiles.Add(profile);
            else
                existingProfile.Items = profile.Items;
        }

        public ProfileMemento GetProfile(int Id)
        {
            return _profiles.First(p => p.ProfileId == Id);
        }

        public void Clear()
        {
            _profiles.Clear();
        }
    }
}