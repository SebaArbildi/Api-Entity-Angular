import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../document.service';
import { ActivatedRoute } from '@angular/router';
import { Paragraph } from '../paragraphs/paragraph';

@Component({
  selector: 'text-main-paragraph',
  templateUrl: './text-main-paragraph.component.html',
})

export class TextParagraphMainComponent implements OnInit {
  title = 'Textos';
  userParagraph: Paragraph;
  documentId: string;
  paragraphId: string;

  constructor(private _documentService: DocumentService, route: ActivatedRoute) {
    this.paragraphId = route.snapshot.params['paragraphId'];
    this.documentId = route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this._documentService.getParagraph(this.paragraphId).subscribe(
      ((obtainedParagraph: Paragraph) => this.userParagraph = obtainedParagraph),
      ((error: any) => console.log(error))
    )
  }
  
  ngOnChanges(): void {
    this._documentService.getParagraph(this.paragraphId).subscribe(
      ((obtainedParagraph: Paragraph) => this.userParagraph = obtainedParagraph),
      ((error: any) => console.log(error))
    )
  }

  deleteText(textId : string) {
    this._documentService.deleteText(textId).subscribe();
  }

}
