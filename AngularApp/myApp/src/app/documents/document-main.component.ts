import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../services/document.service';
import { UserDocument } from '../models/userDocument';
import { IComponentCanBeDeactivated } from '../guards/componentCanBeDeactivated';
import { Observable } from 'rxjs';

@Component({
  selector: 'document-main',
  templateUrl: './document-main.component.html',
})

export class DocumentMainComponent implements OnInit, IComponentCanBeDeactivated {
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
    window.location.reload();
  }

  deleteDocument(documentId: string) {
    if (window.confirm('¿Esta seguro que desea eliminar el documento?')) {
      this._documentService.deleteDocument(documentId).subscribe();
      alert("Documento eliminado");
      window.location.reload();
    }
  }

  isLocked(): Observable<boolean> | Promise<boolean> | boolean {
    return localStorage.getItem('isAdmin') == 'true';
  }

}
