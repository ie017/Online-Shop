import mongoose from "mongoose";

let ProductSchema = new mongoose.Schema({
    _id:String,
    name:String,
    description:String,
    price:{type: Number}
})

const Product = mongoose.model("Product", ProductSchema);
export default Product;