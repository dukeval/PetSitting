import { Photo } from "./Photo";

export interface Pet{
    age:number,
    breed:string,
    name:string,
    sex:string,
    photos:Photo[],
}