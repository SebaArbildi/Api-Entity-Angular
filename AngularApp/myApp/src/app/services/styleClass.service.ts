import { Injectable } from '@angular/core';
import { StyleClass } from '../models/styleClass';
import { Style } from '../models/style';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable, throwError } from 'rxjs';
import { map, tap, catchError } from 'rxjs/operators';



@Injectable()
export class StyleClassService {

    private WEB_API_URL: string = 'http://localhost:4162/api/StyleClass';
    private static token: string;
    private static username: string;

    constructor(private _httpService: Http) {
        StyleClassService.token = localStorage.getItem('userToken');
        StyleClassService.username = localStorage.getItem('username');
     }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

    getStyleClasses(): Observable<Array<StyleClass>> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', StyleClassService.token);
        myHeaders.append('Username', StyleClassService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.get(this.WEB_API_URL, requestOptions).pipe(
            map((response: Response) => <Array<StyleClass>>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    deleteStyleClass(id:string):Observable<any>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', StyleClassService.token);
        myHeaders.append('Username', StyleClassService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders});
        return this._httpService.delete(this.WEB_API_URL+"/"+id, requestOptions);
    }

    addStyleClass(myStyleClass: StyleClass): Observable<any>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', StyleClassService.token);
        myHeaders.append('Username', StyleClassService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.post(this.WEB_API_URL, JSON.stringify(myStyleClass), requestOptions).pipe(
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    addStylesToStyleClass(myStyleClassId: String, style: Style): Observable<any>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', StyleClassService.token);
        myHeaders.append('Username', StyleClassService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.put(this.WEB_API_URL + "/" + myStyleClassId + "/AddStyle", JSON.stringify(style), requestOptions).pipe(
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    deleteStyleFromStyleClass(myStyleClassId: String, styleName: String): Observable<any>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', StyleClassService.token);
        myHeaders.append('Username', StyleClassService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.put(this.WEB_API_URL + "/" + myStyleClassId + "/RemoveStyle", JSON.stringify(styleName), requestOptions).pipe(
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    getStyleClass(id: string): Observable<StyleClass> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', StyleClassService.token);
        myHeaders.append('Username', StyleClassService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });
        return this._httpService.get(this.WEB_API_URL+"/"+id, requestOptions).pipe(
            map((response: Response) =><StyleClass>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }
}