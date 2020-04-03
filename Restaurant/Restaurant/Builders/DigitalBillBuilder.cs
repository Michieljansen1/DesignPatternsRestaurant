using System;
using System.Collections.Generic;
using Restaurant.Models;

namespace Restaurant.Builders
{
    /// <summary>
    /// Bill builder that inherits from the IBillBuilder interface
    /// Used to generate digital bills that include an email address
    /// </summary>
    class DigitalBillBuilder : IBillBuilder
    {
        private Bill _digitalBill = new Bill();

        /// <summary>
        /// Creates a new bill and overrides the current bill 
        /// </summary>
        public void Reset()
        {
            _digitalBill = new Bill();
        }

        public void SetDate(DateTime date)
        {
            _digitalBill.DateTime = date;
        }

        public void SetDeliveryLocation(string location)
        {
            _digitalBill.Location = location;
        }

        public void SetEmailAddress(string email)
        {
            _digitalBill.Email = email;
        }

        public void SetPhysicalAddress(string address)
        {
            _digitalBill.Address = address;
        }

        public void SetProfiles(List<Profile> profiles)
        {
            _digitalBill.Profiles = profiles;
        }

        public void SetTotalPrice(int price)
        {
            _digitalBill.TotalPrice = price;
        }

        public Bill GetBill()
        {
            return _digitalBill;
        }
    }
}
