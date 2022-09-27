"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
const server_1 = __importDefault(require("../server"));
const Address_1 = __importDefault(require("./Address"));
const body_parser_1 = __importDefault(require("body-parser"));
let server = new server_1.default(9090, "mongodb://localhost:27017/address", (0, express_1.default)());
server.start();
server.app.use(body_parser_1.default.json());
server.app.get("/address", (request, response) => {
    Address_1.default.find((error, address) => {
        if (error)
            response.status(500).send(error);
        else
            response.send(address);
    });
});
server.app.get("/address/:id", (request, response) => {
    Address_1.default.findById(request.params.id, (error, address) => {
        if (error)
            response.status(500).send(error);
        else
            response.send(address);
    });
});
server.app.post("/address", (request, response) => {
    let address = new Address_1.default(request.body);
    address.save((error) => {
        if (error)
            response.status(500).send(error);
        else
            response.send(address);
    });
});
server.app.put("/address/:id", (request, response) => {
    Address_1.default.findByIdAndUpdate(request.params.id, request.body, (error) => {
        if (error)
            response.status(500).send(error);
        else
            response.send("Successfully updated address");
    });
});
server.app.delete("/address/:id", (request, response) => {
    Address_1.default.findByIdAndDelete(request.params.id, (error) => {
        if (error)
            response.status(500).send(error);
        else
            response.send("Successfully deleted address");
    });
});
server.app.get("/specification/address", (request, response) => {
    let type = request.query.type;
    Address_1.default.find({ type: type }, (error, address) => {
        if (error)
            response.status(500).send(error);
        else
            response.send(address);
    });
});
