using System;
using System.Reflection;

namespace Restaurant.Extensions
{
    public static class EnumExtensions
    {

        /// <summary>
        /// Get a custom enum attribute
        /// </summary>
        /// <typeparam name="T">the <see cref="Type"/> of the attribute</typeparam>
        /// <param name="value">The <see cref="Enum"/> to get the attribute from</param>
        /// <returns>Returns an instance of the attribute class</returns>
        public static T GetCustomAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name).GetCustomAttribute<T>();
        }
    }
}
