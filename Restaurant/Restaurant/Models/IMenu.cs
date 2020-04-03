using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Types;

namespace Restaurant.Models
{
    /// <summary>
    /// Represents a menu and provides basic functionality 
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// Get the current menu type
        /// </summary>
        /// <returns>Returns <see cref="MenuType"/> of the current menu</returns>
        MenuType GetMenuType();

        /// <summary>
        /// Gets the drink type
        /// </summary>
        /// <returns>Returns <see cref="DrinkType"/> of the current drink</returns>
        DrinkType GetDrinkType();

        /// <summary>
        /// Gets the side type
        /// </summary>
        /// <returns>Returns <see cref="SideType"/> of the current side</returns>
        SideType GetSideType();
        //
        // /// <summary>
        // /// Gets the main type
        // /// </summary>
        // /// <returns>Returns <see cref="T"/> of the current main</returns>
        // T GetMainType();

        /// <summary>
        /// Gets the size type
        /// </summary>
        /// <returns>Returns <see cref="SizeType"/> of the current size</returns>
        SizeType GetSizeType();

        /// <summary>
        /// Gets the total price of this menu
        /// </summary>
        /// <returns>Returns <see cref="double"/> of the total menu price</returns>
        double GetTotalPrice();
    }
}
