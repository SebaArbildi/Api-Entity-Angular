import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable, throwError } from 'rxjs';
import { map, tap, catchError } from 'rxjs/operators';



@Injectable()
export class UserService {

    private WEB_API_URL: string = 'http://localhost:4162/api/User';
    private static token: string;
    private static username: string;

    constructor(private _httpService: Http) {
        UserService.token = localStorage.getItem('userToken');
        UserService.username = localStorage.getItem('username');
     }

    getUsers(): Observable<Array<User>> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', UserService.token);
        myHeaders.append('Username', UserService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.get(this.WEB_API_URL, requestOptions).pipe(
            map((response: Response) => <Array<User>>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    getUser(username: string): Observable<User> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', UserService.token);
        myHeaders.append('Username', UserService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.get(this.WEB_API_URL+"/"+username, requestOptions).pipe(
            map((response: Response) =><User>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    addUser(myUser: User): Observable<any> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', UserService.token);
        myHeaders.append('Username', UserService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });
        return this._httpService.post(this.WEB_API_URL, JSON.stringify(myUser), requestOptions);
    }

    deleteUser(username:string):Observable<any>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', UserService.token);
        myHeaders.append('Username', UserService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders});
        return this._httpService.delete(this.WEB_API_URL+"/"+username, requestOptions);
    }

    modUser(username:string, myUser: User): Observable<User>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', UserService.token);
        myHeaders.append('Username', UserService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.put(this.WEB_API_URL+"/"+username, JSON.stringify(myUser), requestOptions).pipe(
            map((response: Response) =><User>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}