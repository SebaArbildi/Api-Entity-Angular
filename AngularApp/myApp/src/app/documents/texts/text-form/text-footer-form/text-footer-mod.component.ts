import { Component } from '@angular/core';
import { DocumentService } from '../../../../services/document.service';
import { ActivatedRoute } from '@angular/router';
import { TextTempClass } from '../../text-temp';
import { TextClass } from '../../text';

@Component({
    selector: 'text-footer-mod',
    templateUrl: './text-footer-mod.component.html'
})
export class TextFooterModComponent {
    pageTitle: string = "Modificar Texto";
    id: string;
    documentId: string;
    textContent: string;
    marginId: string;
    styleClass: string;
    text: TextClass;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.documentId = route.snapshot.params['id'];
        this.marginId = route.snapshot.params['marginId'];
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