package com.example.customerservice.Item;

import com.example.customerservice.Product.Product;
import lombok.Data;

@Data
public class Item {
    private String id;
    private Product product;
    private int quantity;
    private double price;
}
