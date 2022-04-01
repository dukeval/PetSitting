import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { AppUser } from 'src/app/models/AppUser';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  private currentUserSource = new ReplaySubject<AppUser>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }
  
  login(model:any){
    return this.http.post('https://localhost:5001/api/account/login',model).pipe(
      map((usrs:AppUser) =>{
        const user = usrs;
        if(user){
          localStorage.setItem("appUser", JSON.stringify(user));
          this.currentUserSource.next(user);
        //return this.users
        }
      }));
  }

  setCurrentUser(user:AppUser){
    this.currentUserSource.next(user);
  }

  logout(){
    console.log("log-out");
    this.currentUserSource.next(null);
    localStorage.removeItem("appUser");
  }

  register(){
    console.log("register");
    
  }
}
