package com.example.customerservice.Customer;

import com.example.customerservice.Address.Address;
import com.example.customerservice.Address.AddressRestClient;
import com.example.customerservice.Enums.CustomerStatus;
import com.example.customerservice.Enums.UpdateCartStatus;
import com.example.customerservice.Exceptions.CustomerAddressException;
import com.example.customerservice.Exceptions.CustomerNotFoundException;
import com.example.customerservice.Item.Item;
import com.example.customerservice.Order.Order;
import com.example.customerservice.ShoppingCart.ShoppingCart;
import com.example.customerservice.ShoppingCart.ShoppingCartRestClient;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.Date;
import java.util.UUID;

@Service
@Transactional
@AllArgsConstructor
public class CustomerServicesImpl implements CustomerServices {

    CustomerRepository customerRepository;
    CustomerMapper customerMapper;
    AddressRestClient addressRestClient;
    ShoppingCartRestClient shoppingCartRestClient;

    @Override
    public boolean addCustomer(CustomerDTO customerDTO) {
        Customer customer1 = customerMapper.fromCustomerDTO(customerDTO);
        customerRepository.save(customer1);
        return true;
    }

    @Override
    public boolean addAddress(String customerId, Address address) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        int size = customer.getAddressIds().size();
        if (size >= 2){
            throw new CustomerAddressException("You have three address, it's enough");
        }
        address.setId(UUID.randomUUID().toString());
        customer.getAddressIds().add(address.getId());
        customerRepository.save(customer);
        /* Il faut envoyer une requete avec post vers le service address*/
        addressRestClient.saveAddressFromService(address);
        return true;
    }

    @Override
    public boolean updateAddress(String customerId, Address address) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        /* Il faut envoyer une requete avec put vers le service address*/
        addressRestClient.updateAddressFromService(address.getId(), address);
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
        customer.getAddressIds().remove(addressId);
        customerRepository.save(customer);
        /* Il faut envoyer une requete avec delete vers le service address*/
        addressRestClient.deleteAddressFromService(addressId);
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
        shoppingCart.setId(UUID.randomUUID().toString());
        shoppingCart.setItems(null);
        shoppingCart.setPurchase(null);
        customer.setShoppingCart(shoppingCart);
        /* Il faut envoyer une requete avec post vers le service shoppingCart*/
        shoppingCartRestClient.saveShoppingCart(shoppingCart);
        customerRepository.save(customer);
    }

    @Override
    public boolean updateCart(Item item, UpdateCartStatus cartStatus, String customerId) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        if (cartStatus == UpdateCartStatus.ADD){
            customer.getShoppingCart().getItems().add(item);
            customerRepository.save(customer);
            /* Il faut envoyer une requete avec put vers le service shoppingCart*/
            shoppingCartRestClient.addItemToShoppingCart(customer.getShoppingCart().getId(), item);
        } else {
            customer.getShoppingCart().getItems().remove(item);
            customerRepository.save(customer);
            /* Il faut envoyer une requete avec delete vers le service shoppingCart*/
            shoppingCartRestClient.deleteItemFromShoppingCart(customer.getShoppingCart().getId(), item);
        }
        return true;
    }

    @Override
    public void purchase(String customerId) {
        Customer customer = customerRepository.findById(customerId).orElse(null);
        if (customer == null){
            throw new CustomerNotFoundException("Customer not found !!");
        }
        double sum = 0.0;
        for (Item item : customer.getShoppingCart().getItems()) {
            sum = item.getPrice() + sum;
        }
        Order order = new Order(UUID.randomUUID().toString(), new Date(), sum);
        customer.getShoppingCart().setPurchase(order);
        shoppingCartRestClient.setPurchare(customer.getShoppingCart().getId(), order);
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
}
