using System;

namespace Restaurant.Attributes
{
    /// <summary>
    /// Defines an attribute that sets a price for a given menu item
    /// </summary>
    public class MenuPriceAttribute : Attribute
    {
        /// <summary>
        /// The price of a given menu item
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// Intializes a new instance of <see cref="MenuPriceAttribute"/>
        /// </summary>
        /// <param name="price">The price of a given menu item</param>
        public MenuPriceAttribute(double price)
        {
            Price = price;
        }
    }
}
