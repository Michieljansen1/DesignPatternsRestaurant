

namespace Restaurant.Models
{
    public abstract class Order
    {
        public abstract int GetDiscount();

        
        public abstract string DeliveryType(Types.DeliveryType deliveryType);

    }
}
