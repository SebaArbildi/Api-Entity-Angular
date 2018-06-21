import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../../services/document.service';
import { UserDocument } from '../../models/userDocument';
import { ActivatedRoute } from '@angular/router';
import { Format } from '../format';
import { Printer } from '../printer';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'document-detail',
  templateUrl: './document-detail.component.html',
})

export class DocumentDetailComponent implements OnInit {
  title = 'Detalle del documento';
  userDocument: UserDocument;
  documentId: string;
  formatId: string;
  documentPrinted: string; 
  formats: Array<Format>;
  selectedOption: string  = '0';
  trustedHtml: DomSanitizer;

  showDocument: boolean = false;
  showHeaders: boolean = false;
  showParagraphs: boolean = false;
  showFooters: boolean = false;


  constructor(private _documentService: DocumentService, route: ActivatedRoute) {
    this.documentId = route.snapshot.params['id'];
  }

  capture(){
    this.formatId = this.selectedOption;
  }

  ngOnInit(): void {
    this._documentService.getDocument(this.documentId).subscribe(
      ((obtainedDocument: UserDocument) => this.userDocument = obtainedDocument),
      ((error: any) => console.log(error))
    )

    this._documentService.getFormats().subscribe(
      ((obtainedFormats: Array<Format>) => this.formats = obtainedFormats),
      ((error: any) => console.log(error))
    )
  }

  printDocument(documentId : string, formatId : string) {

    var printer = new Printer(documentId,formatId);

    this._documentService.printDocument(printer).subscribe(
      ((obtainedPrinted: string) => this.documentPrinted = obtainedPrinted),
      ((error: any) => console.log(error))
    )
  }

  toogleDocument(): void {
    this.showDocument = !this.showDocument;
  }

  toggleFooters(): void {
    this.showFooters = !this.showFooters;
  }

  toggleHeaders(): void {
    this.showHeaders = !this.showHeaders;
  }

  toggleParagraphs(): void {
    this.showParagraphs = !this.showParagraphs;
  }
}
