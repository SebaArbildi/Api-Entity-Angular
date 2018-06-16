import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { UserService } from '../services/user.service';

@Component({
  selector: 'user-main',
  templateUrl: './user-main.component.html',
})

export class UserMainComponent implements OnInit {
  title = 'Usuarios';
  users: Array<User>;

  constructor(private _userService: UserService) {
  }

  ngOnInit(): void {
    this._userService.getUsers().subscribe(
      ((obtainedUsers: Array<User>) => this.users = obtainedUsers),
      ((error: any) => console.log(error))
    )
  }

  deleteUser(username:string): void{
    this._userService.deleteUser(username).subscribe();
  }
}

