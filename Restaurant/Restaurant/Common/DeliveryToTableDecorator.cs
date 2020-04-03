using Restaurant.Decorators;
using Restaurant.Models;
using Restaurant.Types;

namespace Restaurant.Common
{
    class DeliveryToTableDecorator : DeliveryDecorator
    {
        public DeliveryToTableDecorator(Order order): base(order)
        {
        }
        public override string DeliveryType(DeliveryType deliveryType)
        {
            if (deliveryType == Types.DeliveryType.TO_TABLE_INSIDE)
            {
                return "Uw bestelling wordt naar uw tafel gebracht.";
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
