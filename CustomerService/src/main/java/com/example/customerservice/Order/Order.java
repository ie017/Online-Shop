package com.example.customerservice.Order;

import lombok.AllArgsConstructor;
import lombok.Data;

import java.util.Date;
@Data @AllArgsConstructor
public class Order {
    private String OrderId;
    private Date OrderDate;
    private double sum;
    private String customerId;
}
