package com.example.customerservice.Product;

import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@FeignClient(name = "PRODUCT-SERVICE")
public interface ProductRestClient {
    @PostMapping(path = "products")
    void setProduct(@RequestBody Product product);
    @DeleteMapping(path = "products/{id}")
    void deleteProduct(@PathVariable(name = "id") String productId);
    @PutMapping(path = "products/{id}")
    void updateProduct(@PathVariable(name = "id") String productId);
    @GetMapping(path = "products")
    List<Product> getAllProducts();
    @GetMapping(path = "products/{id}")
    Product getProduct(@PathVariable(name = "id") String productId);

}
