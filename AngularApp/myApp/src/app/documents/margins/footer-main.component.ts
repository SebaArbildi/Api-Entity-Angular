import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../../services/document.service';
import { UserDocument } from '../../models/userDocument';
import { ActivatedRoute } from '@angular/router';
import { Margin } from './margin';

@Component({
  selector: 'footer-main',
  templateUrl: './footer-main.component.html',
})

export class FooterMainComponent implements OnInit {
  title = 'Pies de pagina';
  userDocument: UserDocument;
  documentId: string;

  constructor(private _documentService: DocumentService, route: ActivatedRoute) {
    this.documentId = route.snapshot.params['id'];
  }

  ngOnInit(): void {
    console.log();
    this._documentService.getDocument(this.documentId).subscribe(
      ((obtainedDocument: UserDocument) => this.userDocument = obtainedDocument),
      ((error: any) => console.log(error))
    )
  }

  ngOnChanges(): void {
    console.log();
    this._documentService.getDocument(this.documentId).subscribe(
      ((obtainedDocument: UserDocument) => this.userDocument = obtainedDocument),
      ((error: any) => console.log(error))
    )
    window.location.reload();
  }

  get getFooter(): Margin {
    for (var i = 0; i < this.userDocument.DocumentMargins.length; i++) {
      if (this.userDocument.DocumentMargins[i].Align == 1) {
        return this.userDocument.DocumentMargins[i];
      }
    }
    return null;
  }

  deleteFooter(footerId: string) {
    if (window.confirm('¿Esta seguro que desea eliminar el pie de pagina?')) {
      this._documentService.deleteMargin(footerId).subscribe();
      alert("Pie de pagina eliminado");
      window.location.reload();
    }
  }

}
