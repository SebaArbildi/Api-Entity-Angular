import { Injectable } from '@angular/core';
import { User } from './user';
import { Http, Response, RequestOptions, Headers} from '@angular/http';
import { Observable, throwError } from 'rxjs';
import{map, tap, catchError} from 'rxjs/operators';



@Injectable()
export class UserService {
    
    private WEB_API_URL : string = 'http://localhost:4162/api/User';

    constructor(private _httpService: Http) {  }

    // esto luego va a ser una llamada a nuestra api REST
    getUsers(): Observable<Array<User>> {
        const myHeaders = new Headers();
        myHeaders.append('Accept','application/json');
        myHeaders.append('Token','994d501f-0944-4da9-95d9-0e2f43ec88e3');
        myHeaders.append('Username','admin');

        const requestOptions = new RequestOptions({headers : myHeaders});

        const p = this._httpService.get(this.WEB_API_URL,requestOptions).pipe(
            map((response : Response) => <Array<User>> response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));

            console.log(p);

        return p;/*this._httpService.get(this.WEB_API_URL,requestOptions).pipe(
            map((response : Response) => <Array<User>> response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError)
        );*/
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error|| 'Server error');
    }

}