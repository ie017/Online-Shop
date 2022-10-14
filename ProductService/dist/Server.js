"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const mongoose_1 = __importDefault(require("mongoose"));
const Eureka_run_1 = __importDefault(require("./EurekaConfig/Eureka-run"));
class Server {
    constructor(port, url, app) {
        this.port = port;
        this.url = url;
        this.app = app;
    }
    start() {
        mongoose_1.default.connect(this.url, error => {
            if (error)
                console.log(error);
            else
                console.log("connected to mongodb 200 ok");
        });
        this.app.get("/", (request, response) => {
            response.send("For rest api Product");
        });
        this.app.listen(this.port, () => {
            console.log("server started");
        });
        (0, Eureka_run_1.default)("product-service", this.port);
    }
}
exports.default = Server;
