using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartService.Data;
using ShoppingCartService.Dtos;
using ShoppingCartService.Models;

namespace ShoppingCartService.Controllers{
    [Route("shoppingcarts")]
    [ApiController]
    public class ShoppingCartRestController : ControllerBase {
        private readonly IShoppingCartRepository _repository;
        private readonly IMapper _mapper;

        public ShoppingCartRestController(IShoppingCartRepository shoppingCartRepository,IMapper mapper){
            _repository = shoppingCartRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}/items")]
        public ActionResult<IEnumerable<Item>> GetAllItemsOfShoppingCart(string id){
            var items = _repository.GetAllItemsOfShoppingCart(id);
            return Ok(items);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShoppingCartReadDto>> GetAllShoppingCart(){
            var shoppingcarts = _repository.GetAllShoppingCart();
            if(shoppingcarts != null){
                return Ok(_mapper.Map<IEnumerable<ShoppingCartReadDto>>(shoppingcarts));
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<ShoppingCartReadDto> GetShoppingCart(string id){
            var shoppingcart = _repository.GetShoppingCart(id);
            if(shoppingcart != null){
                return Ok(_mapper.Map<ShoppingCartReadDto>(shoppingcart));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult<ShoppingCartReadDto> DeleteShoppingCart(string id){
                _repository.DeleteShoppingCart(id);
                return Ok("OK 200");
        }

        [HttpPost]
        public ActionResult<ShoppingCartReadDto> SaveShoppingCart([FromBody] ShoppingCartCreateDto shoppingCartCreateDto){
            var shoppingcart = _mapper.Map<ShoppingCart>(shoppingCartCreateDto);
            if(shoppingcart != null){
                _repository.SaveShoppingCart(shoppingcart);
                return Ok(_mapper.Map<ShoppingCartReadDto>(shoppingcart));
            }
            return NoContent();
        }

        [HttpPost("{id}/items")]
        public ActionResult<Item> AddItemToShoppingCart(string id, [FromBody] ItemCreateDto itemCreateDto){
            var shoppingcart = _repository.GetShoppingCart(id);
            if(shoppingcart != null){
                var item = _mapper.Map<Item>(itemCreateDto);
                item.shoppingcartId = id;
                item.ShoppingCart = shoppingcart;
                _repository.AddItem(id, item);
                return Ok(item);
            }
            return NotFound();
        }

        [HttpDelete("{id}/items/{ItemId}")]
        public ActionResult<ShoppingCartReadDto> DeleteItemFromShoppingCart(string id, string ItemId){
            var shoppingcart = _repository.GetShoppingCart(id);
            if(shoppingcart != null){
                _repository.RemoveItem(id, ItemId);
                return Ok(_mapper.Map<ShoppingCartReadDto>(_repository.GetShoppingCart(id)));
            }
            return NotFound();
        }

        [HttpPut("{id}/items/{ItemId}")]
        public ActionResult<ShoppingCartReadDto> UpdateItemFromShoppingCart(string id, Item itemUpdate){
            var shoppingcart = _repository.GetShoppingCart(id);
            if(shoppingcart != null){
                _repository.UpdateItem(id, itemUpdate);
                return Ok(_mapper.Map<ShoppingCartReadDto>(_repository.GetShoppingCart(id)));
            }
            return NotFound();
        }

        [HttpPut("{id}/purchares")]
        public ActionResult<ShoppingCartReadDto> SetPurchare(string id, [FromBody] Order order){
            var shoppingcart = _repository.GetShoppingCart(id);
            if(shoppingcart != null){
                _repository.SetPurchase(id, order);
                return Ok(_mapper.Map<ShoppingCartReadDto>(_repository.GetShoppingCart(id)));
            }
            return NotFound();
        }
        [HttpDelete("{id}/purchares")]
        public ActionResult<ShoppingCartReadDto> deletePurchare(string id){
            var shoppingcart = _repository.GetShoppingCart(id);
            if(shoppingcart != null){
                _repository.DeletePurchase(id);
                return Ok(_mapper.Map<ShoppingCartReadDto>(_repository.GetShoppingCart(id)));
            }
            return NotFound();
        }

        [HttpGet("{id}/purchares")]
        public string getPurchare(string id){
                return _repository.GetPurchase(id);
        }
    }
}