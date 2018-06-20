import { Component } from '@angular/core';
import { DocumentService } from '../../../document.service';
import { ActivatedRoute } from '@angular/router';
import { TextTempClass } from '../../text-temp';

@Component({
    selector: 'text-paragraph-form',
    templateUrl: './text-paragraph-form.component.html'
})
export class TextParagraphFormComponent {
    pageTitle: string = "Crear Texto";
    documentId: string;
    paragraphId: string;
    StyleClass: string;
    TextContent: string;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.documentId = route.snapshot.params['id'];
        this.paragraphId = route.snapshot.params['paragraphId'];
    }

    addText(): void {
        var textTemp = new TextTempClass(this.StyleClass, this.TextContent, this.paragraphId);
        this._documentService.addTextToParagraph(this.paragraphId,textTemp).subscribe();
    }

}