import { Component, OnInit } from '@angular/core';
import { AppUser } from 'src/app/models/AppUser';

@Component({
  selector: 'app-registerinfo',
  templateUrl: './registerinfo.component.html',
  styles: [
  ]
})
export class RegisterinfoComponent implements OnInit {
  model: AppUser=new AppUser();

  constructor() { }

  ngOnInit(): void {
  }

  save(){
    console.log('Saving');
  }
}
