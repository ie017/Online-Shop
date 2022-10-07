package com.example.customerservice.ShoppingCart;

import com.example.customerservice.Item.Item;
import com.example.customerservice.Order.Order;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.*;

@FeignClient(name = "SHOPPING-CART-SERVICE")
public interface ShoppingCartRestClient {
    @PostMapping(path = "/shoppingcart")
    void saveShoppingCart(@RequestBody ShoppingCart shoppingCart);
    @PutMapping(path = "/shoppingcart/{id}/addItem")
    void addItemToShoppingCart(@PathVariable(name = "id") String shoppingcartId, @RequestBody Item item);
    @DeleteMapping(path = "/shoppingcart/{id}/deleteItem")
    void deleteItemFromShoppingCart(@PathVariable(name = "id") String shoppingcartId, String itemId);
    @PutMapping(path = "/shoppingcart/{id}/setpurchare")
    void setPurchare(@PathVariable(name = "id") String id, @RequestBody Order order);
}
