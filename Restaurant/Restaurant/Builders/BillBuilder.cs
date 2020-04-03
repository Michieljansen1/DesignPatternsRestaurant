using Restaurant.Models;
using System;
using System.Collections.Generic;

namespace Restaurant.Builders
{
    /// <summary>
    /// Interface used to determine which methods all possible bill builders must have
    /// </summary>
    interface IBillBuilder
    {
        void Reset();
        void SetTotalPrice(int price);
        void SetDate(DateTime date);
        void SetProfiles(List<Profile> profiles);
        void SetDeliveryLocation(string location);
        void SetEmailAddress(string email);
        void SetPhysicalAddress(string address);
        Bill GetBill();
    }
}
