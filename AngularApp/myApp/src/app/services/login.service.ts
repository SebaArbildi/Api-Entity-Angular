import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable, throwError } from 'rxjs';
import { map, tap, catchError } from 'rxjs/operators';
import { LoginUser } from '../models/loginUser';



@Injectable()
export class LoginService {

    private WEB_API_URL: string = 'http://localhost:4162/api/Login';

    constructor(private _httpService: Http) {
    }

    login(myUser: User): Observable<LoginUser> {
        const myHeaders = new Headers();
        myHeaders.append('Accept', 'application/json');
        myHeaders.append('Token', localStorage.getItem('userToken'));
        myHeaders.append('Username', localStorage.getItem('username'));

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.put(this.WEB_API_URL, JSON.stringify(myUser), requestOptions).pipe(
            map((response: Response) => <LoginUser>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}