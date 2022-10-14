package com.example.customerservice.Customer;

import com.example.customerservice.Address.Address;
import com.example.customerservice.Address.AddressRestClient;
import com.example.customerservice.Enums.CustomerStatus;
import com.example.customerservice.Enums.UpdateCartStatus;
import com.example.customerservice.Exceptions.CustomerAddressException;
import com.example.customerservice.Exceptions.CustomerNotFoundException;
import com.example.customerservice.Item.Item;
import com.example.customerservice.Order.Order;
import com.example.customerservice.Order.OrderRestClient;
import com.example.customerservice.ShoppingCart.ShoppingCart;
import com.example.customerservice.ShoppingCart.ShoppingCartRestClient;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.*;

@Service
@Transactional
@AllArgsConstructor
public class CustomerServicesImpl implements CustomerServices {

    private CustomerRepository customerRepository;
    private CustomerMapper customerMapper;
    private AddressRestClient addressRestClient;
    private ShoppingCartRestClient shoppingCartRestClient;
    private OrderRestClient orderRestClient;

    @Override
    public boolean addCustomer(CustomerDTO customerDTO) {
        Customer customer1 = customerMapper.fromCustomerDTO(customerDTO);
        customer1.setAddressIds(new ArrayList<String>());
        customer1.setId(UUID.randomUUID().toString());
        customerRepository.save(customer1);
        return true;
    }

    @Override
    public boolean updateCustomer(String customerId, CustomerDTO customerDTO) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        customer.setFirstname(customerDTO.getFirstname());
        customer.setLastname(customerDTO.getLastname());
        customer.setPhone(customerDTO.getPhone());
        customerRepository.save(customer);
        changeEmail(customerId, customerDTO.getEmail());
        changePassword(customerId, customerDTO.getPassword());
        return true;
    }

    @Override
    public boolean addAddress(String customerId, Address address) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        int size = customer.getAddressIds().size();
        if (size > 2){
            throw new CustomerAddressException("You have three address, it's enough");
        }
        address.set_id(UUID.randomUUID().toString());
        /* Il faut envoyer une requete avec post vers le service address*/
        addressRestClient.saveAddressFromService(address);
        customer.getAddressIds().add(address.get_id());
        customerRepository.save(customer);
        return true;
    }

    @Override
    public boolean updateAddress(String customerId, Address address) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        /* Il faut envoyer une requete avec put vers le service address*/
        addressRestClient.updateAddressFromService(address.get_id(), address);
        return true;
    }

    @Override
    public boolean deleteAddress(String customerId, String addressId) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        if (customer.getAddressIds() == null){
            throw new CustomerAddressException("your list of address is empty");
        }
        /* Il faut envoyer une requete avec delete vers le service address*/
        addressRestClient.deleteAddressFromService(addressId);
        customer.getAddressIds().remove(addressId);
        customerRepository.save(customer);
        return true;
    }

    @Override
    public boolean changeEmail(String customerId, String email) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        customer.setEmail(email);
        customerRepository.save(customer);
        return true;
    }

    @Override
    public boolean changePassword(String customerId, String password) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        customer.setPassword(password);
        customerRepository.save(customer);
        return true;
    }

    @Override
    public void emptyCart(String customerId) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        ShoppingCart shoppingCart = new ShoppingCart();
        shoppingCart.setShoppingcartId(UUID.randomUUID().toString());
        shoppingCart.setItems(new ArrayList<Item>());
        shoppingCart.setPurchaseId(null);
        customer.setShoppingCartId(shoppingCart.getShoppingcartId());
        /* Il faut envoyer une requete avec post vers le service shoppingCart*/
        shoppingCartRestClient.saveShoppingCart(shoppingCart);
        customerRepository.save(customer);
    }

    @Override
    public void deleteCart(String customerId) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        shoppingCartRestClient.deleteShoppingCart(customer.getShoppingCartId());
        customer.setShoppingCartId(null);
        customerRepository.save(customer);
    }

    @Override
    public boolean updateCart(Item item, UpdateCartStatus cartStatus, String customerId) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        if (cartStatus == UpdateCartStatus.ADD){
            /* Il faut envoyer une requete avec put vers le service shoppingCart*/
            shoppingCartRestClient.addItemToShoppingCart(customer.getShoppingCartId(), item);
        } else if(cartStatus == UpdateCartStatus.DELETE){
            /* Il faut envoyer une requete avec delete vers le service shoppingCart*/
            shoppingCartRestClient.deleteItemFromShoppingCart(customer.getShoppingCartId(), item.getId());
        } else{
            shoppingCartRestClient.updateItemFromShoppingCart(customer.getShoppingCartId(), item);
        }
        return true;
    }

    @Override
    public void purchase(String customerId) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        List<Item> items = shoppingCartRestClient.getAllItems(customer.getShoppingCartId());
        double sum = 0.0;
        for (Item item : items) {
            sum = item.getPrice() + sum;
        }
        Order order = new Order(UUID.randomUUID().toString(), new Date(), sum, customer.getId());
        shoppingCartRestClient.setPurchare(customer.getShoppingCartId(), order);
        orderRestClient.setOrder(order);
    }

    @Override
    public void updateStatus(String customerId, CustomerStatus status) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        customer.setCustomerStatus(status);
        customerRepository.save(customer);
    }

    @Override
    public void deletePurchase(String customerId) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        orderRestClient.deleteOrder(shoppingCartRestClient.getPurchase(customer.getShoppingCartId()));
        shoppingCartRestClient.deletePurchase(customer.getShoppingCartId());
    }
}
