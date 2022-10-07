using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.Dtos;
using OrderService.Models;
using OrderService.Models.Order;

namespace OrderService.Controllers{
    [Route("orders")]
    [ApiController]
    public class OrdersRestController : ControllerBase{
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrdersRestController(IOrderRepository repository,
         IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        // ActionResult permet de retourner le type de resultat like ok 200, 500, 404...
        public ActionResult<IEnumerable<OrderReadDto>> GetOrders(){
            var orders = _repository.GetAllOrders();
            /* la notation _mapper.Map<OrderReadDto>(orders) basé sur la déclaration qui se trouve dans 
            la classe Profiles -> OrderProfile*/
            if(orders != null){
                return Ok(_mapper.Map<IEnumerable<OrderReadDto>>(orders));
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<OrderReadDto> GetOrder(string id){
            var order = _repository.GetOrderById(id);
            if(order != null){
                return Ok(_mapper.Map<OrderReadDto>(order));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<OrderReadDto> SetOrder(OrderCreateDto order){
            if(order != null){
                Order myOrder = _mapper.Map<Order>(order);
                _repository.CreateOrder(myOrder);
                _repository.SaveChanges();

                return Ok(_mapper.Map<OrderReadDto>(myOrder));
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<OrderReadDto> UpdateOrder(string id, [FromBody] OrderCreateDto orderCreate){
            var searchOrder = _repository.GetOrderById(id);
            if(searchOrder != null){
                _repository.UpdateOrder(id, orderCreate);
                _repository.SaveChanges();
                return Ok(_mapper.Map<OrderReadDto>(_repository.GetOrderById(id)));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult<OrderReadDto> DeleteOrder(string id){
            Order order = _repository.GetOrderById(id);
            if(order != null){
                _repository.DeleteOrder(order);
                return Ok(_mapper.Map<OrderReadDto>(order));
            }
            return NotFound();
        }

        [HttpPut("{id}/bill")]
        public ActionResult<OrderReadDto> SetBill(string id){
            Order searchOrder = _repository.GetOrderById(id);
            if(searchOrder != null){
                _repository.CreateBillingInformatin(searchOrder);
                return Ok(_mapper.Map<OrderReadDto>( _repository.GetOrderById(id)));
            }
            return NotFound();
        }
    }
}