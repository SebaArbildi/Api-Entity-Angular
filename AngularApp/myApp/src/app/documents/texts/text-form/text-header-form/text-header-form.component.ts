import { Component } from '@angular/core';
import { DocumentService } from '../../../../services/document.service';
import { ActivatedRoute } from '@angular/router';
import { TextTempClass } from '../../text-temp';

@Component({
    selector: 'text-header-form',
    templateUrl: './text-header-form.component.html'
})
export class TextHeaderFormComponent {
    pageTitle: string = "Crear Texto";
    documentId: string;
    marginId: string;
    StyleClass: string;
    TextContent: string;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.documentId = route.snapshot.params['id'];
        this.marginId = route.snapshot.params['marginId'];
    }

    addText(): void {
        var textTemp = new TextTempClass(this.StyleClass, this.TextContent, this.marginId);
        this._documentService.addTextToMargin(this.marginId,textTemp).subscribe();
    }

}