using OrderService.Dtos;
using OrderService.Models;
using OrderService.Models.Order;

namespace OrderService.Data{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext){
            _orderContext = orderContext;
        }

        public void CreateBillingInformatin(Order order)
        {
            Bill bill = new Bill() {billingId = Guid.NewGuid().ToString(), issueDate = DateTime.Now, dueDate = DateTime.Now.AddDays(7), sum = order.sum};
            order.billingId = bill.billingId;
            order.orderStatus = Enums.OrderStatus.Shipping;
            _orderContext.orders.Update(order);
            SaveChanges();
        }

        public void CreateOrder(Order order)
        {
            if(order == null){
                throw new ArgumentNullException(nameof(order));
            }
            order.orderStatus = Enums.OrderStatus.New;
            _orderContext.orders.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            if(order.orderStatus != Enums.OrderStatus.Canceled){
                order.orderStatus = Enums.OrderStatus.Canceled;
                _orderContext.orders.Update(order);
                SaveChanges();
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderContext.orders.ToList();
        }

        public Order GetOrderById(string id)
        {
            return _orderContext.orders.FirstOrDefault(Order => Order.OrderId == id)!;
        }

        public bool SaveChanges()
        {
            return (_orderContext.SaveChanges() >= 0);
        }

        public void UpdateOrder(string id, OrderCreateDto orderCreate)
        {   Order oldorder = GetOrderById(id);
            oldorder.OrderDate = orderCreate.OrderDate;
            oldorder.sum = orderCreate.sum;
            oldorder.orderStatus = Enums.OrderStatus.Processing;
            _orderContext.orders.Update(oldorder);
        }
    }
}