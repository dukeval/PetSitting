import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppUser } from 'src/app/models/AppUser';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: [
  ]
})
export class RegisterComponent implements OnInit {
  model: AppUser = new AppUser();

  constructor(private route: Router) { }

  ngOnInit(): void {
  }

  register(){
    console.log(`Register ${this.model.userName} at ${this.model.email}`);
    this.route.navigateByUrl('/page2');
  }

  cancel(){
    console.log('Cancel');
    
  }
}
