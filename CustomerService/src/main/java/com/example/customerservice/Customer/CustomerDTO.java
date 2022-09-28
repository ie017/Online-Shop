package com.example.customerservice.Customer;

import lombok.Data;

@Data
public class CustomerDTO {
    private String firstname;
    private String lastname;
    private String email;
    private String phone;
    private String password;
}
