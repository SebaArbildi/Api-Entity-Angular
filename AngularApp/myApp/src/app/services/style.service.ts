import { Injectable } from '@angular/core';
import { Style } from '../models/style';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable, throwError } from 'rxjs';
import { map, tap, catchError } from 'rxjs/operators';



@Injectable()
export class StyleService {

    private WEB_API_URL: string = 'http://localhost:4162/api/Style';
    private static token: string = '994d501f-0944-4da9-95d9-0e2f43ec88e3';

    constructor(private _httpService: Http) { }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

    getStyles(): Observable<Array<Style>> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', StyleService.token);
        myHeaders.append('Username', 'admin');

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.get(this.WEB_API_URL, requestOptions).pipe(
            map((response: Response) => <Array<Style>>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    getStyle(name: string): Observable<Style> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', StyleService.token);
        myHeaders.append('Username', 'admin');

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.get(this.WEB_API_URL+"/"+name, requestOptions).pipe(
            map((response: Response) =><Style>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    deleteStyle(name:string):Observable<any>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', StyleService.token);

        const requestOptions = new RequestOptions({ headers: myHeaders});
        return this._httpService.delete(this.WEB_API_URL+"/"+name, requestOptions);
    }

    modStyle(name:string, myStyle: Style): Observable<Style>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', StyleService.token);
        myHeaders.append('Username', 'admin');

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.put(this.WEB_API_URL+"/"+name, JSON.stringify(myStyle), requestOptions).pipe(
            map((response: Response) =><Style>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    addStyle(myStyle: Style): Observable<any>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', StyleService.token);
        myHeaders.append('Username', 'admin');

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.post(this.WEB_API_URL, JSON.stringify(myStyle), requestOptions).pipe(
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

}