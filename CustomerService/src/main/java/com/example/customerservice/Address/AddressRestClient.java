package com.example.customerservice.Address;

import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.web.bind.annotation.*;

@FeignClient(name = "ADDRESS-SERVICE")
public interface AddressRestClient {
    @DeleteMapping(path = "/address/{id}")
    void deleteAddressFromService(@PathVariable(name = "id") String id);
    @PostMapping(path = "/address")
    void saveAddressFromService(@RequestBody Address address);
    @PutMapping(path = "/address/{id}")
    void updateAddressFromService(@PathVariable(name = "id") String id, @RequestBody Address address);
}
