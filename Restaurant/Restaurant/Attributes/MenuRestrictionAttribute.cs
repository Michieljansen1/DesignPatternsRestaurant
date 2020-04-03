using System;
using Restaurant.Types;

namespace Restaurant.Attributes
{
    public class MenuRestrictionAttribute : Attribute
    {
        /// <summary>
        /// The type of menu item
        /// </summary>
        public MenuType Type { get; private set; }

        /// <summary>
        /// Intializes a new instance of <see cref="MenuRestrictionAttribute"/>
        /// </summary>
        /// <param name="type">The specific menu type this item is resticted to</param>
        public MenuRestrictionAttribute(MenuType type)
        {
            Type = type;
        }
    }
}
