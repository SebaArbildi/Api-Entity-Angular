import { Component } from '@angular/core';
import { DocumentService } from '../document.service';
import { DocumentTemp } from '../document-temp';

@Component({
    selector: 'document-form',
    templateUrl: './document-form.component.html'
})
export class DocumentFormComponent {
    pageTitle: string = "Crear Documento";
    Title: string;
    StyleClass: string;

    constructor(private _documentService: DocumentService) {
    }

    addDocument(): void {
        var documentTemp = new DocumentTemp(this.Title, this.StyleClass);
        this._documentService.addDocument(documentTemp).subscribe();
      }
  
}