using System.Collections.Generic;
using System.Linq;
using Restaurant.Models;

namespace Restaurant.Memento
{
    class ProfileCaretaker
    {
        private readonly HashSet<Profile> _profiles;

        public ProfileCaretaker()
        {
            _profiles = new HashSet<Profile>();
        }

        public void AddProfile(Profile profile)
        {
            _profiles.Add(profile);
        }

        public Profile GetProfile(int ID)
        {
            return _profiles.ElementAt(ID);
        }

        public void Clear()
        {
            _profiles.Clear();
        }
    }
}
