import { Component } from '@angular/core';
import { DocumentService } from '../../document.service';
import { MarginTemp } from '../margin-temp';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'footer-form',
    templateUrl: './footer-form.component.html'
})
export class FooterFormComponent {
    pageTitle: string = "Crear Pie de pagina";
    documentId: string;
    styleClass: string;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.documentId = route.snapshot.params['id'];
    }
    
    addFooter(): void {
        var footerTemp = new MarginTemp(this.styleClass, 1, this.documentId);
        this._documentService.addMargin(this.documentId,"FOOTER",footerTemp).subscribe();
    }

}