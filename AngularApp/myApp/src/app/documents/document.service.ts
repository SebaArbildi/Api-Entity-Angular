import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers} from '@angular/http';
import { Observable, throwError } from 'rxjs';
import{map, tap, catchError} from 'rxjs/operators';
import { Document } from './document';
import { Printer } from './printer';
import { Format } from './format';
import { DocumentTemp } from './document-temp';

@Injectable()
export class DocumentService {
    
    private WEB_API_URL : string = 'http://localhost:4162/api/';
    private static token: string = '994d501f-0944-4da9-95d9-0e2f43ec88e3';
    private static username: string = "admin";

    constructor(private _httpService: Http) {  }

    getDocuments(): Observable<Array<Document>> {
        const myHeaders = new Headers();
        myHeaders.append('Accept','application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username', DocumentService.username);

        const requestOptions = new RequestOptions({headers : myHeaders});

        const p = this._httpService.get(this.WEB_API_URL+"Document",requestOptions).pipe(
            map((response : Response) => <Array<Document>> response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));

        return p;
    }

    getFormats(): Observable<Array<Format>> {
        const myHeaders = new Headers();
        myHeaders.append('Accept','application/json');
        myHeaders.append('Token',DocumentService.token);
        myHeaders.append('Username',DocumentService.username);

        const requestOptions = new RequestOptions({headers : myHeaders});

        const p = this._httpService.get(this.WEB_API_URL+"Format",requestOptions).pipe(
            map((response : Response) => <Array<Format>> response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));

        return p;
    }


    getDocument(id : string): Observable<Document>{
        const myHeaders = new Headers();
        myHeaders.append('Accept','application/json');
        myHeaders.append('Token',DocumentService.token);
        myHeaders.append('Username',DocumentService.username);

        const requestOptions = new RequestOptions({headers : myHeaders});

        return this._httpService.get(this.WEB_API_URL+"Document/"+id,requestOptions).pipe(
            map((response : Response) => <Document> response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));

    }

    deleteDocument(id : string): Observable<any>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username',DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders});
        return this._httpService.delete(this.WEB_API_URL+"Document/"+id, requestOptions);
    }

    printDocument(printer : Printer) : Observable<string>{ 
        const myHeaders = new Headers();
        myHeaders.append('Content-Type','application/json');
        myHeaders.append('Token',DocumentService.token);
        myHeaders.append('Username','admin');

        const requestOptions = new RequestOptions({headers : myHeaders});

        return this._httpService.post(this.WEB_API_URL+"PrintDocumentHtml", JSON.stringify(printer), requestOptions).pipe(
            map((response : Response) => <string> response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    addDocument(documentTemp : DocumentTemp): Observable<any> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username', DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });
        return this._httpService.post(this.WEB_API_URL+"Document", JSON.stringify(documentTemp), requestOptions);
    }

    modDocument(id : string, documentTemp : DocumentTemp): Observable<Document>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username', DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.put(this.WEB_API_URL+"Document/"+id, JSON.stringify(documentTemp), requestOptions).pipe(
            map((response: Response) =><Document>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error|| 'Server error');
    }

}