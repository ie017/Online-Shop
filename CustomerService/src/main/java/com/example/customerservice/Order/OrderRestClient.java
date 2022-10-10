package com.example.customerservice.Order;

import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

@FeignClient(name = "ORDER-SERVICE")
public interface OrderRestClient {
    @PostMapping(path = "orders")
    void setOrder(@RequestBody Order order);
}
