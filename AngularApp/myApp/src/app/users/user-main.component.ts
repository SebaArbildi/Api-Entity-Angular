import { Component, OnInit } from '@angular/core';
import { User } from './user';
import { UserService } from './user.service';

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
    this.title = username;
   // this._userService.deleteUser(username);
  }
}

