import { Component } from '@angular/core';
import { AppUser } from './models/AppUser';
import { AccountsService } from './services/accounts.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'client';

  constructor(private account:AccountsService){}

  ngOnInit(){
    this.setCurrentUser();
  }

  setCurrentUser(){
    const user: AppUser = JSON.parse(localStorage.getItem("appUser"));
    this.account.setCurrentUser(user);
  }
}
