import { Component, OnInit, OnChanges } from '@angular/core';
import { DocumentService } from '../../../services/document.service';
import { ActivatedRoute } from '@angular/router';
import { Paragraph } from '../paragraph';

@Component({
    selector: 'paragraph-mod',
    templateUrl: './paragraph-mod.component.html'
})
export class ParagraphModComponent implements OnInit, OnChanges {
    pageTitle: string = "Modificar Parrafo";
    id: string;
    documentId: string;
    styleClass: string;
    paragraph: Paragraph;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.documentId = route.snapshot.params['id'];
        this.id = route.snapshot.params['paragraphId'];
    }

    ngOnInit(): void {
        this._documentService.getParagraph(this.id).subscribe(
            ((obtainedParagraph: Paragraph) => this.paragraph = obtainedParagraph),
            ((error: any) => console.log(error))
        )
    }

    ngOnChanges(): void {
        this._documentService.getParagraph(this.id).subscribe(
            ((obtainedParagraph: Paragraph) => this.paragraph = obtainedParagraph),
            ((error: any) => console.log(error))
        )
    }

    modParagraph(): void {
        this._documentService.modParagraph(this.id, this.paragraph).subscribe();
    }

}