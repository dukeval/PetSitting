import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  users: User[] = [];

  constructor(private http: HttpClient) { }

  getUsers(){
    return this.http.get('https://localhost:5001/api/users').pipe(
      map(usrs =>{
        console.log('wait');
        //this.users = usrs;
        console.log(usrs);
        //return this.users
      })
    );

    // return this.http.get<any[]>('https://localhost:5001/api/users').subscribe(
    //   usrs =>{
    //     console.log('wait');
    //     //this.users = usrs;
    //     console.log(usrs);
    //     //return this.users
    //   }
    // );
  }
}
