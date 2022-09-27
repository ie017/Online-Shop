import express, { request, response } from "express";
import Server from "../server";
import Address from "./Address";
import bodyParser from"body-parser";


let server = new Server(9090, "mongodb://localhost:27017/address", express());
server.start();

server.app.use(bodyParser.json());

server.app.get("/address",(request, response)=>{
    Address.find((error, address)=>{
        if(error) response.status(500).send(error);
        else response.send(address);
    });
});

server.app.get("/address/:id", (request, response)=>{
    Address.findById(request.params.id, (error, address)=>{
        if(error) response.status(500).send(error);
        else response.send(address)
    });
});

server.app.post("/address", (request, response)=>{
    let address = new Address(request.body);
    address.save((error)=>{
        if(error) response.status(500).send(error);
        else response.send(address);
    });
});

server.app.put("/address/:id", (request, response)=>{
    Address.findByIdAndUpdate(request.params.id, request.body, (error)=>{
        if(error) response.status(500).send(error);
        else response.send("Successfully updated address");
    });
});

server.app.delete("/address/:id", (request, response)=>{
    Address.findByIdAndDelete(request.params.id, (error)=>{
        if(error) response.status(500).send(error);
        else response.send("Successfully deleted address");
    });
});

server.app.get("/specification/address", (request, response)=>{
    let type:string = request.query.type as string;
    Address.find({type: type} , (error, address)=>{
        if(error) response.status(500).send(error);
        else response.send(address);
    });
});



