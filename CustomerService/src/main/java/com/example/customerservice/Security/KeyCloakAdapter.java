package com.example.customerservice.Security;

import org.keycloak.adapters.springboot.KeycloakSpringBootConfigResolver;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class KeyCloakAdapter {
    @Bean
    KeycloakSpringBootConfigResolver springBootConfigResolver(){
        return new KeycloakSpringBootConfigResolver();
    }
}
