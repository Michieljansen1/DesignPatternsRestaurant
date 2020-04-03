using Restaurant.Models;

namespace Restaurant.Decorators
{
    abstract class DeliveryDecorator : Order
    {
        private Order order;
        public DeliveryDecorator(Order order)
        {
            this.order = order;
        }

        public Order GetOrder()
        {
            return this.order;
        }
    }
}
