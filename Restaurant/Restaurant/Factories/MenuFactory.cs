using System;
using Restaurant.Models;

namespace Restaurant.Factories
{
    public abstract class MenuFactory<T> where T : Enum
    {
        /// <summary>
        /// Constructs a new menu
        /// </summary>
        /// <returns>Returns <see cref="IMenu{T}"/> of the newly constructed menu</returns>
        protected abstract IMenu<T> ConstuctMenu();

        /// <summary>
        /// Create a new menu
        /// </summary>
        /// <returns>Returns <see cref="IMenu{T}"/> of the newly created menu</returns>
        public IMenu<T> CreateMenu()
        {
            return ConstuctMenu();
        }
    }
}
