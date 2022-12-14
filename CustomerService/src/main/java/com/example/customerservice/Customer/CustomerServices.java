package com.example.customerservice.Customer;

import com.example.customerservice.Address.Address;
import com.example.customerservice.Enums.CustomerStatus;
import com.example.customerservice.Enums.UpdateCartStatus;
import com.example.customerservice.Item.Item;
import com.example.customerservice.Product.Product;

import javax.ws.rs.Produces;
import java.util.List;

public interface CustomerServices {
    boolean addCustomer(CustomerDTO customerDTO);
    boolean updateCustomer(String customerId, CustomerDTO customerDTO);
    boolean addAddress(String customerId, Address address);
    boolean updateAddress(String customerId, Address address);
    boolean deleteAddress(String customerId, String addressId);
    boolean changeEmail(String customerId, String email);
    boolean changePassword(String customerId, String password);
    void emptyCart(String customerId);
    void deleteCart(String customerId);
    boolean updateCart(Item item, UpdateCartStatus cartStatus, String customerId);
    void purchase(String customerId);
    void updateStatus(String customerId, CustomerStatus status);
    void deletePurchase(String id);
}
