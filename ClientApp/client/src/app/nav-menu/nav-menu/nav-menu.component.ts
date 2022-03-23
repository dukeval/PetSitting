import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/User';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  model:any = {};
  userName: string;
  user: User;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  login(){
    console.log("log-in");
  }

  logout(){
    console.log("log-out");
  }

  toggle(){
    this.isExpanded =!this.isExpanded;
  }
}
