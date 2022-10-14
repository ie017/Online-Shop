package com.example.customerservice.ShoppingCart;

import com.example.customerservice.Item.Item;
import com.example.customerservice.Order.Order;
import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@FeignClient(name = "SHOPPING-CART-SERVICE")
public interface ShoppingCartRestClient {
    @GetMapping(path = "/shoppingcarts/{id}")
    ShoppingCart getshoppingcart(@PathVariable(name = "id") String id);
    @PostMapping(path = "/shoppingcarts")
    void saveShoppingCart(@RequestBody ShoppingCart shoppingCart);
    @PostMapping(path = "/shoppingcarts/{id}/items")
    void addItemToShoppingCart(@PathVariable(name = "id") String shoppingcartId, @RequestBody Item item);
    @DeleteMapping(path = "/shoppingcarts/{id}/items/{itemId}")
    void deleteItemFromShoppingCart(@PathVariable(name = "id") String shoppingcartId,@PathVariable(name = "itemId") String itemId);
    @PutMapping(path = "/shoppingcarts/{id}/purchares")
    void setPurchare(@PathVariable(name = "id") String id, @RequestBody Order order);
    @DeleteMapping(path = "/shoppingcarts/{id}/purchares")
    void  deletePurchase(@PathVariable(name = "id") String id);
    @DeleteMapping(path = "/shoppingcarts/{id}")
    void deleteShoppingCart(@PathVariable(name = "id") String id);
    @PutMapping(path = "/shoppingcarts/{id}/items")
    void updateItemFromShoppingCart(@PathVariable(name = "id") String shoppingCartId,@RequestBody Item item);
    @GetMapping(path = "/shoppingcarts/{id}/items")
    List<Item> getAllItems(@PathVariable(name = "id") String id);
    @GetMapping(path = "/shoppingcarts/{id}/purchares")
    String getPurchase(@PathVariable(name = "id") String id);

}
