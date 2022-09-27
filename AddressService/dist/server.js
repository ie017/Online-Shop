"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const mongoose_1 = __importDefault(require("mongoose"));
const eureka_helper_1 = __importDefault(require("./EurekaConfig/eureka-helper"));
class Server {
    constructor(port, url, app) {
        this.port = port;
        this.url = url;
        this.app = app;
    }
    start() {
        mongoose_1.default.connect(this.url, (error) => {
            if (error)
                console.log(error);
            else
                console.log("Connected to mongodb 200 OK");
        });
        this.app.get("/", (request, response) => {
            response.send("For rest api address");
        });
        this.app.listen(this.port, () => {
            console.log("Server started");
        });
        (0, eureka_helper_1.default)('address-service', this.port);
    }
}
exports.default = Server;
