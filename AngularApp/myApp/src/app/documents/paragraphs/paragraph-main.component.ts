import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../../services/document.service';
import { UserDocument } from '../../models/userDocument';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'paragraph-main',
  templateUrl: './paragraph-main.component.html',
})

export class ParagraphMainComponent implements OnInit {
  title = 'Parrafos';
  userDocument: UserDocument;
  documentId: string;

  constructor(private _documentService: DocumentService, route: ActivatedRoute) {
    this.documentId = route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this._documentService.getDocument(this.documentId).subscribe(
      ((obtainedDocument: UserDocument) => this.userDocument = obtainedDocument),
      ((error: any) => console.log(error)),
      
    )
  }

  ngOnChanges(): void {
    this._documentService.getDocument(this.documentId).subscribe(
      ((obtainedDocument: UserDocument) => this.userDocument = obtainedDocument),
      ((error: any) => console.log(error)),
      
    )
  }

  deleteParagraph(paragraphId : string) {
    this._documentService.deleteParagraph(paragraphId).subscribe();
  }

}
