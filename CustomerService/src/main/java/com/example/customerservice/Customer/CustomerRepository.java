package com.example.customerservice.Customer;

import org.springframework.data.jpa.repository.JpaRepository;

    public interface CustomerRepository extends JpaRepository<Customer, String> {

}
