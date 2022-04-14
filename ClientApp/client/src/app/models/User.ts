import { Pet } from "./Pet";

export interface User{
    name: string;
    age: number;
    city: string;
    state: string;
    picture: string;
    pets: Pet[];//string[];
    username: string;
}