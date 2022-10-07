import mongoose from "mongoose";
import {AddressState} from "../Enums/AddressState";

let addressSchema = new mongoose.Schema({
    _id:String,
    street:String,
    streetNumber:{type: Number},
    zipCode:{type: Number},
    city:{type: String, required: true },
    country:{type: String, required: true, },
    homePhone:{type: String, required: true, },
    type:{type: String, enum: AddressState, required: true}
});

const Address = mongoose.model("Address", addressSchema);
export default Address;