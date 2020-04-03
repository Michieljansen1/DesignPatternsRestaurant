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
                return "The food will be send to your table inside.";
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
