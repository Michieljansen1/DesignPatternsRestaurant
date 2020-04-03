
namespace Restaurant.Models
{
    public class Delivery : Order
    {
        public override string DeliveryType(Types.DeliveryType deliveryType)
        {
            if (deliveryType == Types.DeliveryType.TO_COUNTER)
            {
                return "Please wait for your food at the counter";
            }
            else
            {
                return "The input is not valid";
            }
        }
        public override int GetDiscount()
        {
            return 0;
        }
    }
}
