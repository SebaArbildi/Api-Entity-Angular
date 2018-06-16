import { Component } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'user-mod',
    templateUrl: './user-mod.component.html'
})
export class UserModComponent {
    pageTitle: string = "Mod User";
    user: User;

    constructor(private _userService: UserService, route: ActivatedRoute) {
        this.user = new User("", "", "", "", "", false);
        console.log(this.user);
        this.user.Username = route.snapshot.params['username'];
    }

    ngOnInit(): void {
        this._userService.getUser(this.user.Username).subscribe(
            ((obtainedUser: User) => this.user = obtainedUser),
            ((error: any) => console.log(error))
        )
    }

    modUser(): void{
        this._userService.modUser(this.user).subscribe(
            ((error: any) => console.log(error))
        )
    }

}