package com.example.customerservice.Address;

import lombok.Data;

@Data
public class Address {
    private String _id;
    private String street;
    private String streetNumber;
    private Number zepCode;
    private String city;
    private String country;
    private String homePhone;
    private String type;
}
