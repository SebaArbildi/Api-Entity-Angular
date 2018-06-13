import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../document.service';
import { Document } from '../document';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'document-detail',
  templateUrl: './document-detail.component.html',
})

export class DocumentDetailComponent implements OnInit {
  title = 'Detalle del documento';
  document: Document;
  documentId: string;

  constructor(private _documentService: DocumentService, route: ActivatedRoute) {
    this.documentId = route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this._documentService.getDocument(this.documentId).subscribe(
      ((obtainedDocument: Array<Document>) => this.document = obtainedDocument),
      ((error: any) => console.log(error))
    )
      /*((obtainedUsers: Array<User>) => console.log(obtainedUsers)),
      ((error: any) => console.log(error))*/

    
  }
}
