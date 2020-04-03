using Restaurant.Decorators;
using Restaurant.Models;

namespace Restaurant.Common
{
    class DeliveryToTableDecorator : DeliveryDecorator
    {
        public DeliveryToTableDecorator(Order order): base(order)
        {
        }
        public override string DeliveryType(string deliveryType)
        {
            if (deliveryType == "ToTableInside")
            {
                return "The food will be send to your table inside.";
            }
            else if (deliveryType == "ToTableOutside")
            {
                return "The food will be send to your table outside.";
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
