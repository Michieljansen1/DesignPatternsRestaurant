using Restaurant.Types;

namespace Restaurant.Models
{
    public abstract class Order
    {
        public abstract int GetDiscount();


        public abstract string DeliveryType(DeliveryType deliveryType);
    }
}