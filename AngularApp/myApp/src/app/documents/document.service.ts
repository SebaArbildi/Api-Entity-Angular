import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers} from '@angular/http';
import { Observable, throwError } from 'rxjs';
import{map, tap, catchError} from 'rxjs/operators';
import { UserDocument } from '../models/userDocument';
import { Printer } from './printer';
import { Format } from './format';
import { DocumentTemp } from './document-temp';
import { Margin } from './margins/margin';
import { Paragraph } from './paragraphs/paragraph';
import { MarginTemp } from './margins/margin-temp';
import { TextTempClass } from './texts/text-temp';
import { ParagraphTemp } from './paragraphs/paragraph-temp';

@Injectable()
export class DocumentService {
    
    private WEB_API_URL : string = 'http://localhost:4162/api/';
    private static token: string = '994d501f-0944-4da9-95d9-0e2f43ec88e3';
    private static username: string = "admin";

    constructor(private _httpService: Http) {  }

    getDocuments(): Observable<Array<UserDocument>> {
        const myHeaders = new Headers();
        myHeaders.append('Accept','application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username', DocumentService.username);

        const requestOptions = new RequestOptions({headers : myHeaders});

        const p = this._httpService.get(this.WEB_API_URL+"Document",requestOptions).pipe(
            map((response : Response) => <Array<UserDocument>> response.json()),
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


    getDocument(id : string): Observable<UserDocument>{
        const myHeaders = new Headers();
        myHeaders.append('Accept','application/json');
        myHeaders.append('Token',DocumentService.token);
        myHeaders.append('Username',DocumentService.username);

        const requestOptions = new RequestOptions({headers : myHeaders});

        return this._httpService.get(this.WEB_API_URL+"Document/"+id,requestOptions).pipe(
            map((response : Response) => <UserDocument> response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));

    }

    getMargin(id : string): Observable<Margin>{
        const myHeaders = new Headers();
        myHeaders.append('Accept','application/json');
        myHeaders.append('Token',DocumentService.token);
        myHeaders.append('Username',DocumentService.username);

        const requestOptions = new RequestOptions({headers : myHeaders});

        return this._httpService.get(this.WEB_API_URL+"Margin/"+id,requestOptions).pipe(
            map((response : Response) => <Margin> response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));

    }

    getParagraph(id : string): Observable<Paragraph>{
        const myHeaders = new Headers();
        myHeaders.append('Accept','application/json');
        myHeaders.append('Token',DocumentService.token);
        myHeaders.append('Username',DocumentService.username);

        const requestOptions = new RequestOptions({headers : myHeaders});

        return this._httpService.get(this.WEB_API_URL+"Paragraph/"+id,requestOptions).pipe(
            map((response : Response) => <Paragraph> response.json()),
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

    deleteMargin(id : string): Observable<any>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username',DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders});
        return this._httpService.delete(this.WEB_API_URL+"Margin/"+id, requestOptions);
    }

    deleteParagraph(id : string): Observable<any>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username',DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders});
        return this._httpService.delete(this.WEB_API_URL+"Paragraph/"+id, requestOptions);
    }

    deleteText(id : string): Observable<any>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username',DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders});
        return this._httpService.delete(this.WEB_API_URL+"Text/"+id, requestOptions);
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

    modDocument(id : string, documentTemp : DocumentTemp): Observable<UserDocument>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username', DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.put(this.WEB_API_URL+"Document/"+id, JSON.stringify(documentTemp), requestOptions).pipe(
            map((response: Response) =><UserDocument>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    addMargin(documentId: string, align: string, marginTemp : MarginTemp): Observable<any> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username', DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });
        return this._httpService.post(this.WEB_API_URL+"Document/"+documentId+"/Margin/"+align, JSON.stringify(marginTemp), requestOptions);
    }

    modMargin(id : string, marginTemp : MarginTemp): Observable<Margin>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username', DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.put(this.WEB_API_URL+"Margin/"+id, JSON.stringify(marginTemp), requestOptions).pipe(
            map((response: Response) =><Margin>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    addParagraph(documentId: string, paragraphTemp : ParagraphTemp): Observable<any> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username', DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });
        return this._httpService.post(this.WEB_API_URL+"Document/"+documentId+"/Paragraph", JSON.stringify(paragraphTemp), requestOptions);
    }

    modParagraph(id : string, paragraphTemp : ParagraphTemp): Observable<Margin>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username', DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.put(this.WEB_API_URL+"Paragraph/"+id, JSON.stringify(paragraphTemp), requestOptions).pipe(
            map((response: Response) =><Margin>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    modText(id : string, textTemp : TextTempClass): Observable<TextTempClass>{
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username', DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });

        return this._httpService.put(this.WEB_API_URL+"Text/"+id, JSON.stringify(textTemp), requestOptions).pipe(
            map((response: Response) =><TextTempClass>response.json()),
            tap(data => console.log('Los datos que obtuvimos fueron: ' + JSON.stringify(data))),
            catchError(this.handleError));
    }

    addTextToMargin(marginId: string, textTemp : TextTempClass): Observable<any> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username', DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });
        return this._httpService.put(this.WEB_API_URL+"Margin/"+marginId+"/SetText", JSON.stringify(textTemp), requestOptions);
    }

    addTextToParagraph(paragraphId: string, textTemp : TextTempClass): Observable<any> {
        const myHeaders = new Headers();
        myHeaders.append('Content-Type', 'application/json');
        myHeaders.append('Token', DocumentService.token);
        myHeaders.append('Username', DocumentService.username);

        const requestOptions = new RequestOptions({ headers: myHeaders });
        return this._httpService.post(this.WEB_API_URL+"Paragraph/"+paragraphId+"/Text", JSON.stringify(textTemp), requestOptions);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error|| 'Server error');
    }

}