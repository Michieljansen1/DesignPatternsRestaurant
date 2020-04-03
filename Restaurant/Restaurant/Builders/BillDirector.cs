using Restaurant.Models;
using System;
using System.Collections.Generic;


namespace Restaurant.Builders
{
    /// <summary>
    /// This class can be used to build analog and digital bills
    /// </summary>
    class BillDirector
    {
        private IBillBuilder _billBuilder;

        public IBillBuilder BillBuilder
        {
            set { _billBuilder = value; }
        }

        public void SetBuilder(IBillBuilder billBuilder) {
            _billBuilder = billBuilder;
        }

        /// <summary>
        /// Builds an analog bill, without an email address
        /// This is an easier implementation, so the ordermachine 
        /// does not have to make a builder and bill separately
        /// </summary>
        public void BuildAnalogBill(DateTime dateTime, List<Profile> profiles, int totalPrice, string location, string address)
        {
            _billBuilder.SetDate(dateTime);
            _billBuilder.SetProfiles(profiles);
            _billBuilder.SetTotalPrice(totalPrice);
            _billBuilder.SetDeliveryLocation(location);
            _billBuilder.SetPhysicalAddress(address);
        }

        /// <summary>
        /// Builds a digital bill, with an email address
        /// This is an easier implementation, so the ordermachine 
        /// does not have to make a builder and bill separately
        /// </summary>
        public void BuildDigitalBill(DateTime dateTime, List<Profile> profiles, int totalPrice, string location, string address, string email)
        {
            _billBuilder.SetDate(dateTime);
            _billBuilder.SetProfiles(profiles);
            _billBuilder.SetTotalPrice(totalPrice);
            _billBuilder.SetDeliveryLocation(location);
            _billBuilder.SetPhysicalAddress(address);
            _billBuilder.SetEmailAddress(email);
        }

        public Bill GetBill() {
            return _billBuilder.GetBill();
        }

    }
}
