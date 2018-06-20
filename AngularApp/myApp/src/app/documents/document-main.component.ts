import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../services/document.service';
import { UserDocument } from '../models/userDocument';

@Component({
  selector: 'document-main',
  templateUrl: './document-main.component.html',
})

export class DocumentMainComponent implements OnInit {
  title = 'Documentos';
  documents: Array<UserDocument>;

  constructor(private _documentService: DocumentService) {
  }

  ngOnInit(): void {
    this._documentService.getDocuments().subscribe(
      ((obtainedDocuments: Array<UserDocument>) => this.documents = obtainedDocuments),
      ((error: any) => console.log(error))
    )
  }

  ngOnChanges(): void {
    this._documentService.getDocuments().subscribe(
      ((obtainedDocuments: Array<UserDocument>) => this.documents = obtainedDocuments),
      ((error: any) => console.log(error))
    )
  }

  deleteDocument(documentId : string) {
    this._documentService.deleteDocument(documentId).subscribe();
  }

}
