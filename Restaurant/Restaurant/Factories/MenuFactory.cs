using System;
using Restaurant.Models;

namespace Restaurant.Factories
{
    public abstract class MenuFactory
    {

        protected abstract IMenu ConstuctMenu();


        public IMenu CreateMenu()
        {
            return ConstuctMenu();
        }
    }
}
