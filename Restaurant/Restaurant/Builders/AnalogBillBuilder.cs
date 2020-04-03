using System;
using System.Collections.Generic;
using Restaurant.Models;

namespace Restaurant.Builders
{
    class AnalogBillBuilder : IBillBuilder
    {
        /// <summary>
        /// Bill builder that inherits from the IBillBuilder interface
        /// Used to generate analog bills that do not include an email address
        /// </summary>
        private Bill _analogBill = new Bill();

        /// <summary>
        /// Creates a new bill and overrides the current bill 
        /// </summary>
        public void Reset()
        {
            _analogBill = new Bill();
        }

        public void SetDate(DateTime date)
        {
            _analogBill.DateTime = date;
        }

        public void SetDeliveryLocation(string location)
        {
            _analogBill.Location = location;
        }

        public void SetEmailAddress(string email)
        {
            _analogBill.Email = "";
        }

        public void SetPhysicalAddress(string address)
        {
            _analogBill.Address = address;
        }

        public void SetProfiles(List<Profile> profiles)
        {
            _analogBill.Profiles = profiles;
        }

        public void SetTotalPrice(int price)
        {
            _analogBill.TotalPrice = price;
        }

        public Bill GetBill()
        {
            return _analogBill;
        }
    }
}
