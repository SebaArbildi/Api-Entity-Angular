import { Component } from '@angular/core';
import { DocumentService } from '../../document.service';
import { ActivatedRoute } from '@angular/router';
import { ParagraphTemp } from '../paragraph-temp';

@Component({
    selector: 'paragraph-form',
    templateUrl: './paragraph-form.component.html'
})
export class ParagraphFormComponent {
    pageTitle: string = "Crear Parrafo";
    documentId: string;
    styleClass: string;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.documentId = route.snapshot.params['id'];
    }

    addParagraph(): void {
        var paragraphTemp = new ParagraphTemp(this.styleClass, 2, this.documentId);
        this._documentService.addParagraph(this.documentId,paragraphTemp).subscribe();
    }

}