using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Memento;

namespace Restaurant.Models
{
    /// <summary>
    /// The bill that will be made available for the customer
    /// Using the bill builder, this can either be a digital or analog bill
    /// </summary>
    class Bill
    {
        private double _totalPrice;
        private DateTime _dateTime;
        private List<ProfileMemento> _profiles;
        private string _location;
        private string _email;
        private string _address;

        public double TotalPrice
        {
            get => _totalPrice;
            set => _totalPrice = value;
        }

        public DateTime DateTime
        {
            get => _dateTime;
            set => _dateTime = value;
        }

        public List<ProfileMemento> Profiles
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


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("=================\n");
            sb.Append($"Datum: {DateTime.Now}\n");
            sb.Append($"Locatie: {Location}\n");
            sb.Append($"Email: {Email}\n");
            sb.Append($"Adres: {Address}\n");
            sb.Append("=================\n");
            _profiles.ForEach(profile => {
                sb.Append($"Profiel: {profile.ProfileId}\n");
                profile.Items.ForEach(item => {
                    sb.Append($"> {item.GetMenuType()} \t {item.GetTotalPrice()} euro\n");
                });
            });
            sb.Append("=================\n");
            sb.Append($"Totaal: {TotalPrice} euro\n");
            return sb.ToString();
        }
    }
    
}
