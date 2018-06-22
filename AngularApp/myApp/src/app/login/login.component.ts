import { Component } from '@angular/core';
import { LoginUser } from '../models/loginUser';
import { LoginService } from '../services/login.service';

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent {
    pageTitle: string = "Login";
    user: LoginUser;
    userPostLogin: LoginUser;
    resp: string;
    auth: boolean;

    constructor(private _loginService: LoginService) {
        this.user = new LoginUser("", "", "", "", "", false, "");
    }

    login(): void {
        this._loginService.login(this.user).subscribe(
            ((response: LoginUser) => this.loadCredentials(response)),
            ((error: any) => this.viewError(error))
        );
    }

    viewError(error: any){
        alert("Datos incorrectos");
        console.log(error);
    }

    loadCredentials(user:LoginUser): void {
        window.location.assign("/welcome");
        localStorage.setItem('username', user.Username);
        localStorage.setItem('userToken', user.Token)

        if (user.IsAdmin) {
            localStorage.setItem('isAdmin', 'true');
        }
        else {
            localStorage.setItem('isAdmin', 'false');
        }

        alert("Login exitoso");
    }
}