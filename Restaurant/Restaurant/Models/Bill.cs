using System;
using System.Collections.Generic;

namespace Restaurant.Models
{
    /// <summary>
    /// The bill that will be made available for the customer
    /// Using the bill builder, this can either be a digital or analog bill
    /// </summary>
    class Bill
    {
        private int _totalPrice;
        private DateTime _dateTime;
        private List<Profile> _profiles;
        private string _location;
        private string _email;
        private string _address;

        public int TotalPrice
        {
            get => _totalPrice;
            set => _totalPrice = value;
        }

        public DateTime DateTime
        {
            get => _dateTime;
            set => _dateTime = value;
        }

        public List<Profile> Profiles
        {
            get => _profiles;
            set => _profiles = value;
        }

        public string Location
        {
            get => _location;
            set => _location = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }
    }
    
}
