package com.example.customerservice.ShoppingCart;

import com.example.customerservice.Item.Item;
import com.example.customerservice.Order.Order;
import lombok.Data;
import java.util.Collection;

@Data
public class ShoppingCart {
    private String shoppingcartId;
    private Collection<Item> items;
    private String purchaseId;
}
