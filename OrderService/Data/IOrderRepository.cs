using OrderService.Dtos;
using OrderService.Models;
using OrderService.Models.Order;

namespace OrderService.Data{
    public interface IOrderRepository{
        bool SaveChanges();
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(string id);
        void CreateOrder(Order order);
        void UpdateOrder(string id, OrderCreateDto orderCreateDto);
        void CreateBillingInformatin(Order order);
        void DeleteOrder(Order order);

    }
}