import { Component } from '@angular/core';
import { DocumentService } from '../../../document.service';
import { ActivatedRoute } from '@angular/router';
import { TextTempClass } from '../../text-temp';
import { TextClass } from '../../text';

@Component({
    selector: 'text-paragraph-mod',
    templateUrl: './text-paragraph-mod.component.html'
})
export class TextParagraphModComponent {
    pageTitle: string = "Modificar Texto";
    id: string;
    documentId: string;
    textContent: string;
    paragraphId: string;
    styleClass: string;
    text: TextClass;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.documentId = route.snapshot.params['id'];
        this.paragraphId = route.snapshot.params['paragraphId'];
        this.id = route.snapshot.params['textId'];
    }

    ngOnInit(): void {
        this._documentService.getText(this.id).subscribe(
            ((obtainedText: TextClass) => this.text = obtainedText),
            ((error: any) => console.log(error))
        )
    }

    ngOnChanges(): void {
        this._documentService.getText(this.id).subscribe(
            ((obtainedText: TextClass) => this.text = obtainedText),
            ((error: any) => console.log(error))
        )
    }

    modText(): void {
        this._documentService.modText(this.id, this.text).subscribe();
    }

}