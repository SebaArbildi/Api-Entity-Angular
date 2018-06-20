import { Component, OnChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserDocument } from '../../models/userDocument';
import { DocumentService } from '../document.service';

@Component({
    selector: 'document-mod',
    templateUrl: './document-mod.component.html'
})

export class DocumentModComponent {
    pageTitle: string = "Modificar Documento";
    Id: string;
    Title: string;
    StyleClass: string;
    document: UserDocument;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.Id = route.snapshot.params['id'];
    }

    ngOnInit(): void {
        this._documentService.getDocument(this.Id).subscribe(
            ((obtainedDocument: UserDocument) => this.document = obtainedDocument),
            ((error: any) => console.log(error))
        )
    }

    ngOnChanges(): void {
        this._documentService.getDocument(this.Id).subscribe(
            ((obtainedDocument: UserDocument) => this.document = obtainedDocument),
            ((error: any) => console.log(error))
        )
    }

    modDocument(): void {
        this._documentService.modDocument(this.Id, this.document).subscribe();
    }

}