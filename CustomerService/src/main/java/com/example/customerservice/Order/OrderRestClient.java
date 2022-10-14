package com.example.customerservice.Order;

import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

@FeignClient(name = "ORDER-SERVICE")
public interface OrderRestClient {
    @PostMapping(path = "orders")
    void setOrder(@RequestBody Order order);
    @DeleteMapping(path = "orders/{id}")
    void deleteOrder(@PathVariable(name = "id") String purchase);
}
