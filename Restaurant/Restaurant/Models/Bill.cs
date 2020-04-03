using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Memento;

namespace Restaurant.Models
{
    /// <summary>
    ///     The bill that will be made available for the customer
    ///     Using the bill builder, this can either be a digital or analog bill
    /// </summary>
    class Bill
    {
        public double TotalPrice { get; set; }

        public DateTime DateTime { get; set; }

        public List<ProfileMemento> Profiles { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("=================\n");
            sb.Append($"Datum: {DateTime.Now}\n");
            sb.Append($"Locatie: {Location}\n");
            sb.Append($"Email: {Email}\n");
            sb.Append($"Adres: {Address}\n");
            sb.Append("=================\n");
            Profiles.ForEach(profile => {
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