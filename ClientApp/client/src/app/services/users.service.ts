import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/User';


@Injectable({
  providedIn: 'root'
})
export class UsersService {
  users: User[] = [];

  constructor(private http: HttpClient) { }

  getUsers(){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('appUser')).token
      })
    }
    
    if(this.users.length>0)
      return of(this.users);
 
    return this.http.get<User[]>('https://localhost:5001/api/users', httpOptions).pipe(
      map((usrs:User[]) =>{
        this.users = usrs;
        return usrs;
      })
    );
  }
}
