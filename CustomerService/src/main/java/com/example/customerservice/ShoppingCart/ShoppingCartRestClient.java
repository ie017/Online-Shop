package com.example.customerservice.ShoppingCart;

import com.example.customerservice.Item.Item;
import com.example.customerservice.Order.Order;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.*;

@FeignClient(name = "SHOPPING-CART-SERVICE")
public interface ShoppingCartRestClient {
    @GetMapping(path = "/shoppingcarts/{id}")
    ShoppingCart getshoppingcart(@PathVariable(name = "id") String id);
    @PostMapping(path = "/shoppingcarts")
    void saveShoppingCart(@RequestBody ShoppingCart shoppingCart);
    @PutMapping(path = "/shoppingcarts/{id}/addItem")
    void addItemToShoppingCart(@PathVariable(name = "id") String shoppingcartId, @RequestBody Item item);
    @DeleteMapping(path = "/shoppingcarts/{id}/deleteItem/{itemId}")
    void deleteItemFromShoppingCart(@PathVariable(name = "id") String shoppingcartId,@PathVariable(name = "itemId") String itemId);
    @PutMapping(path = "/shoppingcarts/{id}/setpurchares")
    void setPurchare(@PathVariable(name = "id") String id, @RequestBody Order order);
    @DeleteMapping(path = "/shoppingcarts/{id}")
    void deleteShoppingCart(@PathVariable(name = "id") String id);
}
