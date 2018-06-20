import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable, throwError } from 'rxjs';
import { map, tap, catchError } from 'rxjs/operators';



@Injectable()
export class LoginService {

    private WEB_API_URL: string = 'http://localhost:4162/api/Login';
    private static token: string;
    private static username: string;

    constructor(private _httpService: Http) {
        LoginService.token = localStorage.getItem('userToken');
        LoginService.username = localStorage.getItem('username');
    }

    login(myUser: User): Observable<string> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', LoginService.token);
        myHeaders.append('Username', LoginService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.put(this.WEB_API_URL, JSON.stringify(myUser), requestOptions).pipe(
            map((response: Response) => <string>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}