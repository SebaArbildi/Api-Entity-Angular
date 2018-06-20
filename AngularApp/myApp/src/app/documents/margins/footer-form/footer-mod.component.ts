import { Component } from '@angular/core';
import { DocumentService } from '../../document.service';
import { MarginTemp } from '../margin-temp';
import { ActivatedRoute } from '@angular/router';
import { Margin } from '../margin';

@Component({
    selector: 'footer-mod',
    templateUrl: './footer-mod.component.html'
})
export class FooterModComponent {
    pageTitle: string = "Modificar Pie de pagina";
    id: string;
    documentId: string;
    styleClass: string;
    margin: Margin;

    constructor(private _documentService: DocumentService, route: ActivatedRoute) {
        this.documentId = route.snapshot.params['id'];
        this.id = route.snapshot.params['marginId'];
    }

    ngOnInit(): void {
        this._documentService.getMargin(this.id).subscribe(
            ((obtainedMargin: Margin) => this.margin = obtainedMargin),
            ((error: any) => console.log(error))
        )
    }

    ngOnChanges(): void {
        this._documentService.getMargin(this.id).subscribe(
            ((obtainedMargin: Margin) => this.margin = obtainedMargin),
            ((error: any) => console.log(error))
        )
    }

    modFooter(): void {
        this._documentService.modMargin(this.id, this.margin).subscribe();
    }

}