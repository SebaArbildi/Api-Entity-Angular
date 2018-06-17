import { Component } from '@angular/core';
import { DocumentService } from '../document.service';
import { ActivatedRoute } from '@angular/router';
import { DocumentTemp } from '../document-temp';

@Component({
    selector: 'document-mod',
    templateUrl: './document-mod.component.html'
})
export class DocumentModComponent {
    pageTitle: string = "Modificar Documento";
    Id: string;
    Title: string;
    StyleClass: string;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.Id = route.snapshot.params['id'];
    }

    modDocument(): void {
        var documentTemp = new DocumentTemp(this.Title, this.StyleClass);
        this._documentService.modDocument(this.Id,documentTemp).subscribe();
      }
  
}