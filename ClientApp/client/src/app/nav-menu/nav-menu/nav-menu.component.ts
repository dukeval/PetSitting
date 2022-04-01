import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { AppUser } from 'src/app/models/AppUser';
import { AccountsService } from 'src/app/services/accounts.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  model:any = {};
  userName: string;
  user: AppUser;
  loggedIn = false;

  constructor(private router: Router, public accounts: AccountsService) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  login(){
    this.accounts.login(this.model)
    .subscribe(res=>{
      this.accounts.currentUser$.pipe(take(1)).subscribe(act=>{
       this.user = act;
      });
      this.router.navigateByUrl("/users");
    });
  }

  logout(){
    this.accounts.logout();
    this.router.navigateByUrl("/");
  }

  toggle(){
    this.isExpanded =!this.isExpanded;
  }

  collapse(){
    this.isExpanded = false;
  }

  getCurrentUser(){
    this.accounts.currentUser$.subscribe(user=>{
      this.loggedIn = !!user;
    },error=>{
      console.log(error);
      
    }
    )
  }
}
