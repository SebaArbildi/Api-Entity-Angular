import { Component } from '@angular/core';
import { User } from '../models/user';
import { LoginService } from '../services/login.service';
import { MockNgModuleResolver } from '@angular/compiler/testing';

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent {
    pageTitle: string = "Login";
    user: User;
    resp: string;
    auth: boolean;

    constructor(private _loginService: LoginService) {
        this.user = new User("", "", "", "", "", false);
    }

    log(){
        console.log(localStorage.getItem('userToken'));
        console.log(localStorage.getItem('username'));
    }

    login(): void {
        this._loginService.login(this.user).subscribe(
            ((response: string) => localStorage.setItem('userToken',response)),
            ((error: any) => console.log(error))
        );

        localStorage.setItem('username',this.user.Username);
    }


}