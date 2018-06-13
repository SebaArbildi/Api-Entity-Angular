import { Injectable } from '@angular/core';
import { User } from './user';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable, throwError } from 'rxjs';
import { map, tap, catchError } from 'rxjs/operators';



@Injectable()
export class UserService {

    private WEB_API_URL: string = 'http://localhost:4162/api/User';

    constructor(private _httpService: Http) { }

    getUsers(): Observable<Array<User>> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', '994d501f-0944-4da9-95d9-0e2f43ec88e3');
        myHeaders.append('Username', 'admin');

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.get(this.WEB_API_URL, requestOptions).pipe(
            map((response: Response) => <Array<User>>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    addUser(myUser: User): Observable<any> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', '994d501f-0944-4da9-95d9-0e2f43ec88e3');
        myHeaders.append('Username', 'admin');

        const requestOptions = new RequestOptions({ headers: myHeaders });
        console.log(myUser);
        return this._httpService.post(this.WEB_API_URL, JSON.stringify(myUser), requestOptions).pipe(
            map((response: Response)=>  response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError)
        );
    }

    /*deleteUser(username:string):Observable<any>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', '994d501f-0944-4da9-95d9-0e2f43ec88e3');

        const requestOptions = new RequestOptions({ headers: myHeaders});
        return this._httpService.delete(this.WEB_API_URL+"/"+username, requestOptions);
    }*/

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}