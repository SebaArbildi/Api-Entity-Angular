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
    resp: any;
    auth: boolean;

    constructor(private _loginService: LoginService) {
        this.user = new User("", "", "", "", "", false);
    }

    login(): void {
        this._loginService.login(this.user).subscribe(
            ((response: any) => this.resp = response),
            ((error: any) => console.log(error))
        );
      }

  
}