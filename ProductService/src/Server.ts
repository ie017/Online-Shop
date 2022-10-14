import express from "express";
import mongoose from "mongoose";
import registerWithEureka from "./EurekaConfig/Eureka-run";

export default class Server {
    constructor(private port: number, private url: string, public app: express.Application){}

    public start() : void{
        mongoose.connect(this.url, error=>{
            if(error) console.log(error);
            else console.log("connected to mongodb 200 ok");
        });

        this.app.get("/", (request, response) => {
            response.send("For rest api Product");
        });

        this.app.listen(this.port, ()=>{
            console.log("server started");
        });
        registerWithEureka("product-service", this.port);
    }
}