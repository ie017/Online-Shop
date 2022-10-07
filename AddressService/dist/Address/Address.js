"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const mongoose_1 = __importDefault(require("mongoose"));
const AddressState_1 = require("../Enums/AddressState");
let addressSchema = new mongoose_1.default.Schema({
    _id: String,
    street: String,
    streetNumber: { type: Number },
    zipCode: { type: Number },
    city: { type: String, required: true },
    country: { type: String, required: true, },
    homePhone: { type: String, required: true, },
    type: { type: String, enum: AddressState_1.AddressState, required: true }
});
const Address = mongoose_1.default.model("Address", addressSchema);
exports.default = Address;
