import { Component } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'user-mod',
    templateUrl: './user-mod.component.html'
})
export class UserModComponent {
    pageTitle: string = "Mod User";
    username: string;
    user: User;

    constructor(private _userService: UserService, route: ActivatedRoute) {
        this.user = new User("", "", "", "", "", false);
        console.log(this.user);
        this.username = route.snapshot.params['username'];
        this.user.Username = this.username;
    }

    ngOnInit(): void {
        this._userService.getUser(this.user.Username).subscribe(
            ((obtainedUser: User) => this.user = obtainedUser),
            ((error: any) => console.log(error))
        )
    }

    ngOnChanges(): void {
        this._userService.getUser(this.user.Username).subscribe(
            ((obtainedUser: User) => this.user = obtainedUser),
            ((error: any) => console.log(error))
        )
        window.location.reload();
    }

    modUser(): void{
        this._userService.modUser(this.username, this.user).subscribe(
            ((error: any) => console.log(error))
        )
        alert("Usuario modificado");
        window.location.reload();
    }

}