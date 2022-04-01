import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/models/User';

@Component({
  selector: 'app-membercard',
  templateUrl: './membercard.component.html',
  styleUrls: ['./membercard.component.css']
})
export class MembercardComponent implements OnInit {
  @Input() user: User
  
  constructor() { }

  ngOnInit(): void {
  }

}
