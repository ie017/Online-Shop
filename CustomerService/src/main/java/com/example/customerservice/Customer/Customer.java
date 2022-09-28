package com.example.customerservice.Customer;

import com.example.customerservice.Address.Address;
import com.example.customerservice.Enums.CustomerStatus;
import com.example.customerservice.ShoppingCart.ShoppingCart;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.ToString;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import java.util.Collection;

@Entity
@Data @AllArgsConstructor @NoArgsConstructor @ToString
public class Customer {
    @Id @GeneratedValue(strategy = GenerationType.IDENTITY)
    private String id;
    private String firstname;
    private String lastname;
    private String email;
    private String phone;
    private String password;
    private CustomerStatus customerStatus;
    private Collection<String> addressIds;
    private ShoppingCart shoppingCart;
}
