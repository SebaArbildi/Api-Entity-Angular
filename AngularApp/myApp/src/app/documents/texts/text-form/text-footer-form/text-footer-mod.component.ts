import { Component } from '@angular/core';
import { DocumentService } from '../../../document.service';
import { ActivatedRoute } from '@angular/router';
import { TextTempClass } from '../../text-temp';

@Component({
    selector: 'text-footer-mod',
    templateUrl: './text-footer-mod.component.html'
})
export class TextFooterModComponent {
    pageTitle: string = "Modificar Texto";
    id: string;
    documentId: string;
    textContent: string;
    marginId: string;
    styleClass: string;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.documentId = route.snapshot.params['id'];
        this.marginId = route.snapshot.params['marginId'];
        this.id = route.snapshot.params['textId'];
    }

    modText(): void {
        var textTemp = new TextTempClass(this.styleClass, this.textContent, this.marginId);
        this._documentService.modText(this.id,textTemp).subscribe();
    }

}