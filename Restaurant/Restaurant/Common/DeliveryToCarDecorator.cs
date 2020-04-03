using Restaurant.Decorators;
using Restaurant.Models;
using Restaurant.Types;

namespace Restaurant.Common
{
    class DeliveryToCarDecorator : DeliveryDecorator
    {
        public DeliveryToCarDecorator(Order order) : base(order)
        {

        }
        public override string DeliveryType(DeliveryType deliveryType)
        {
            if(deliveryType == Types.DeliveryType.TO_CAR_A)
            {
                return "Uw bestelling zal naar uw auto gebracht worden";
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
