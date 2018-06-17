import { Component } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
    selector: 'user-form',
    templateUrl: './user-form.component.html'
})
export class UserFormComponent {
    pageTitle: string = "Add User";
    name: string;
    lastName: string;
    username: string;
    password: string;
    mail: string;
    isAdmin: boolean;
    user: User;

    constructor(private _userService: UserService) {
    }

    addUser(): void {
        this.user = new User(this.name, this.lastName, this.username, this.password, this.mail, 
            this.isAdmin);
        this._userService.addUser(this.user).subscribe();
      }
  
}