using Restaurant.Types;

namespace Restaurant.Models
{
    public class Delivery : Order
    {
        public override string DeliveryType(DeliveryType deliveryType)
        {
            if (deliveryType == Types.DeliveryType.TO_COUNTER)
            {
                return "U kunt uw bestelling bij de kassa afhalen";
            }

            return "The input is not valid";
        }

        public override int GetDiscount()
        {
            return 0;
        }
    }
}