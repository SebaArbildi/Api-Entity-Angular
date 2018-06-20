import { Component } from '@angular/core';
import { DocumentService } from '../../document.service';
import { MarginTemp } from '../margin-temp';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'header-form',
    templateUrl: './header-form.component.html'
})
export class HeaderFormComponent {
    pageTitle: string = "Crear Encabezado";
    documentId: string;
    styleClass: string;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.documentId = route.snapshot.params['id'];
    }

    addHeader(): void {
        var headerTemp = new MarginTemp(this.styleClass, 0, this.documentId);
        this._documentService.addMargin(this.documentId,"HEADER",headerTemp).subscribe();
    }

}