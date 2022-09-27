import mongoose from "mongoose";
import {AddressState} from "../Enums/AddressState";

let addressSchema = new mongoose.Schema({
    street:String,
    streetNumber:{type: String, required: true },
    zipCode:{type: Number, required: true },
    city:{type: String, required: true },
    country:{type: String, required: true, },
    phone:{type: String, required: true, },
    type:{type: String, enum: AddressState, required: true}
});

const Address = mongoose.model("Address", addressSchema);
export default Address;