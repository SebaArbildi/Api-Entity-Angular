import { Component } from '@angular/core';
import { DocumentService } from '../../../document.service';
import { ActivatedRoute } from '@angular/router';
import { TextTempClass } from '../../text-temp';

@Component({
    selector: 'text-paragraph-mod',
    templateUrl: './text-paragraph-mod.component.html'
})
export class TextParagraphModComponent {
    pageTitle: string = "Modificar Texto";
    id: string;
    documentId: string;
    textContent: string;
    paragraphId: string;
    styleClass: string;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.documentId = route.snapshot.params['id'];
        this.paragraphId = route.snapshot.params['paragraphId'];
        this.id = route.snapshot.params['textId'];
    }

    modText(): void {
        var textTemp = new TextTempClass(this.styleClass, this.textContent, this.paragraphId);
        this._documentService.modText(this.id,textTemp).subscribe();
    }

}