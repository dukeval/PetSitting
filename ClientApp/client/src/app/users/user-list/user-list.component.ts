import { Component, OnInit } from '@angular/core';
import { User } from '../../models/User';
import { UsersService } from 'src/app/services/users.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  user$: Observable<User[]>;
  source: string = "Users";

  constructor(private userService: UsersService) { }

  ngOnInit(): void {
    this.user$ = this.userService.getUsers();
  }

}
