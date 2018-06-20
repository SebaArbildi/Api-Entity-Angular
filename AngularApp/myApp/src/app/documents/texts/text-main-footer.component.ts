import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../document.service';
import { ActivatedRoute } from '@angular/router';
import { Margin } from '../margins/margin';

@Component({
  selector: 'text-main-footer',
  templateUrl: './text-main-footer.component.html',
})

export class TextFooterMainComponent implements OnInit {
  title = 'Textos';
  userMargin: Margin;
  documentId: string;
  marginId: string;

  constructor(private _documentService: DocumentService, route: ActivatedRoute) {
    this.documentId = route.snapshot.params['id'];
    this.marginId = route.snapshot.params['marginId'];
  }

  ngOnInit(): void {
    this._documentService.getMargin(this.marginId).subscribe(
      ((obtainedMargin: Margin) => this.userMargin = obtainedMargin),
      ((error: any) => console.log(error))
    )
  }

  ngOnChanges(): void {
    this._documentService.getMargin(this.marginId).subscribe(
      ((obtainedMargin: Margin) => this.userMargin = obtainedMargin),
      ((error: any) => console.log(error))
    )
  }

  deleteText(textId: string) {
    this._documentService.deleteText(textId).subscribe();
  }

}
