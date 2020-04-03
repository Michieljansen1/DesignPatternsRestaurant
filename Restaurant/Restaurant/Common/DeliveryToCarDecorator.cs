using Restaurant.Decorators;
using Restaurant.Models;

namespace Restaurant.Common
{
    class DeliveryToCarDecorator : DeliveryDecorator
    {
        public DeliveryToCarDecorator(Order order) : base(order)
        {

        }
        public override string DeliveryType(string deliveryType)
        {
            if(deliveryType == "ToCarA")
            {
                return "The food will be send to your car on parking lot A";
            }
            else if (deliveryType == "ToCarB")
            {
                return "The food will be send to your car on parking lot B.";
            }
            else
            {
                return this.GetOrder().DeliveryType(deliveryType);
            }
        }

        public override int GetDiscount()
        {
            return 5;
        }
    }
}
