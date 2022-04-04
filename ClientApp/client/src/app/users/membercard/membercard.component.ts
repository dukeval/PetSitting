import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/User';

@Component({
  selector: 'app-membercard',
  templateUrl: './membercard.component.html',
  styleUrls: ['./membercard.component.css']
})
export class MembercardComponent implements OnInit {
  @Input() user: any
  @Input() source: string
  
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  viewProfile(){
    this.router.navigateByUrl(`${this.source}/Profile`);
  }

}
