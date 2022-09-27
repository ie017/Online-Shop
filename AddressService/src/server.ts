import express, { Request, Response } from "express";
import mongoose from "mongoose";
import registerWithEureka from "./EurekaConfig/eureka-helper";

export default class Server {
    constructor(private port: number, private url: string,
        public app: express.Application) {
    }

    public start(): void {
        mongoose.connect(this.url, (error) => {
            if (error) console.log(error);
            else console.log("Connected to mongodb 200 OK");
        });

        this.app.get("/", (request, response) => {
            response.send("For rest api address");
        });

        this.app.listen(this.port, () => {
            console.log("Server started");
        });

        registerWithEureka('address-service', this.port);
    }
}