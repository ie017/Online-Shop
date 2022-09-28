package com.example.customerservice.ShoppingCart;

import com.example.customerservice.Item.Item;
import com.example.customerservice.Order.Order;
import lombok.Data;
import java.util.Collection;

@Data
public class ShoppingCart {
    private String id;
    private Collection<Item> items;
    private Order purchase;
}
