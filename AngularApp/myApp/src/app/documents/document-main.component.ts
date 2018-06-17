import { Component, OnInit } from '@angular/core';
import { DocumentService } from './document.service';
import { Document } from './document';

@Component({
  selector: 'document-main',
  templateUrl: './document-main.component.html',
})

export class DocumentMainComponent implements OnInit {
  title = 'Documentos';
  documents: Array<Document>;

  constructor(private _documentService: DocumentService) {
  }

  ngOnInit(): void {
    this._documentService.getDocuments().subscribe(
      ((obtainedDocuments: Array<Document>) => this.documents = obtainedDocuments),
      ((error: any) => console.log(error))
    )
  }

  deleteDocument(documentId : string) {
    this._documentService.deleteDocument(documentId).subscribe();
  }

}
