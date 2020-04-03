
namespace Restaurant.Models
{
    public class Delivery : Order
    {
        public override string DeliveryType(string deliveryType)
        {
            if (deliveryType == "ToCounter")
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
