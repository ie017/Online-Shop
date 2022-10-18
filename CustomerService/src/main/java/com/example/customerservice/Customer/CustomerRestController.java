package com.example.customerservice.Customer;

import com.example.customerservice.Address.Address;
import com.example.customerservice.Enums.CustomerStatus;
import com.example.customerservice.Enums.UpdateCartStatus;
import com.example.customerservice.Item.Item;
import lombok.AllArgsConstructor;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

@AllArgsConstructor
@RestController
public class CustomerRestController {

    private CustomerServicesImpl customerServices;

    @PostMapping(path = "/customer")
    @PreAuthorize("hasAuthority('CUSTOMER')")
    public boolean saveCustomer(@RequestBody CustomerDTO customerDTO){
        return customerServices.addCustomer(customerDTO);
    }
    @PutMapping(path = "/customer/{id}")
    @PreAuthorize("hasAuthority('CUSTOMER')")
    public boolean updateCustomer(@PathVariable(name = "id") String id, @RequestBody CustomerDTO customerDTO){
        return customerServices.updateCustomer(id, customerDTO);
    }
    @PostMapping(path = "/customer/{id}/address")
    @PreAuthorize("hasAuthority('CUSTOMER')")
    public boolean saveAddress(@PathVariable(name = "id") String id, @RequestBody Address address){
        return customerServices.addAddress(id, address);
    }
    @DeleteMapping(path = "/customer/{id}/address/{addressId}")
    @PreAuthorize("hasAuthority('CUSTOMER')")
    public boolean deleteAddress(@PathVariable(name = "id") String id, @PathVariable(name = "addressId") String addressId){
        return customerServices.deleteAddress(id, addressId);
    }
    @PutMapping(path = "/customer/{id}/address")
    @PreAuthorize("hasAuthority('CUSTOMER')")
    public boolean updateAddress(@PathVariable(name = "id") String id, @RequestBody Address address){
        /* Il faut mettre l'id d'adresse dans le corps de la requete */
        return customerServices.updateAddress(id, address);
    }
    @PostMapping(path = "/customer/{id}/shoppingcart/")
    @PreAuthorize("hasAuthority('CUSTOMER')")
    public void createShoppingCart(@PathVariable(name = "id") String id){
        customerServices.emptyCart(id);
    }
    @PutMapping(path = "/customer/{id}/shoppingcart/add")
    public void addItemToShoppingCart(@PathVariable(name = "id") String id, @RequestBody Item item){
        customerServices.updateCart(item, UpdateCartStatus.ADD, id);
    }
    @PutMapping(path = "/customer/{id}/shoppingcart/delete")
    @PreAuthorize("hasAuthority('CUSTOMER')")
    public void deleteItemToShoppingCart(@PathVariable(name = "id") String id, @RequestBody Item item){
        customerServices.updateCart(item, UpdateCartStatus.DELETE, id);
    }
    @PostMapping(path = "/customer/{id}/purchase")
    @PreAuthorize("hasAuthority('CUSTOMER')")
    public void addPurchase(@PathVariable(name = "id") String id){
        customerServices.purchase(id);
    }
    @DeleteMapping(path = "/customer/{id}/purchase")
    @PreAuthorize("hasAuthority('CUSTOMER')")
    public void deletePurchase(@PathVariable(name = "id") String id){
        customerServices.deletePurchase(id);
    }
    @PutMapping(path = "/customer/{id}/status")
    @PreAuthorize("hasAuthority('CUSTOMER')")
    public void updateStatus(@PathVariable(name = "id") String id, @RequestBody CustomerStatus customerStatus){
        customerServices.updateStatus(id,customerStatus);
    }

}
