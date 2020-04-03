using Restaurant.Models;

namespace Restaurant.Memento
{
    /// <summary>
    ///     Loads and saves the given profile
    /// </summary>
    internal class ProfileManagerMemento
    {
        private Profile _profile;

        public Profile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }
    }
}