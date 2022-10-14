"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const Server_1 = __importDefault(require("../Server"));
const Product_1 = __importDefault(require("./Product"));
const body_parser_1 = __importDefault(require("body-parser"));
const express_1 = __importDefault(require("express"));
let server = new Server_1.default(5444, "mongodb://localhost:27017/products", (0, express_1.default)());
server.start();
server.app.use(body_parser_1.default.json());
server.app.get("/products", (request, response) => {
    Product_1.default.find((error, products) => {
        if (error)
            response.status(500).send(error);
        else
            response.send(products);
    });
});
server.app.get("/products/:id", (request, response) => {
    Product_1.default.findById(request.params.id, (error, product) => {
        if (error)
            response.status(500).send(error);
        else
            response.send(product);
    });
});
server.app.post("/products", (request, response) => {
    let product = new Product_1.default(request.body);
    product.save((error) => {
        if (error)
            response.status(500).send(error);
        else
            response.send(product);
    });
});
server.app.put("/products/:id", (request, response) => {
    Product_1.default.findByIdAndUpdate(request.params.id, request.body, (error) => {
        if (error)
            response.status(500).send(error);
        else
            response.send("Successfuly update Product");
    });
});
server.app.delete("/products/:id", (request, response) => {
    Product_1.default.findByIdAndDelete(request.params.id, (error) => {
        if (error)
            response.status(500).send(error);
        else
            response.send("Successfully deleted product");
    });
});
