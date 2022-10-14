import Server from "../Server";
import Product from "./Product";
import bodyparser from "body-parser";
import express from "express";


let server = new Server(5444, "mongodb://localhost:27017/products", express());
server.start();

server.app.use(bodyparser.json());

server.app.get("/products", (request, response)=>{
    Product.find((error, products)=>{
        if(error) response.status(500).send(error);
        else response.send(products);

    });
});

server.app.get("/products/:id", (request, response) => {
    Product.findById(request.params.id, (error, product) => {
        if(error) response.status(500).send(error);
        else response.send(product);
    });
});

server.app.post("/products", (request, response) => {
    let product = new Product(request.body);
    product.save((error)=>{
        if(error) response.status(500).send(error);
        else response.send(product);
    });
});

server.app.put("/products/:id", (request, response) => {
    Product.findByIdAndUpdate(request.params.id, request.body, (error) => {
        if(error) response.status(500).send(error);
        else response.send("Successfuly update Product");
    });
});

server.app.delete("/products/:id", (request, response)=>{
    Product.findByIdAndDelete(request.params.id, (error)=>{
        if(error) response.status(500).send(error);
        else response.send("Successfully deleted product");
    });
});