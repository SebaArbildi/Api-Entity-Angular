import { Component, OnInit, OnChanges } from '@angular/core';
import { DocumentService } from '../../../services/document.service';
import { MarginTemp } from '../margin-temp';
import { ActivatedRoute } from '@angular/router';
import { Margin } from '../margin';

@Component({
    selector: 'header-mod',
    templateUrl: './header-mod.component.html'
})
export class HeaderModComponent implements OnInit, OnChanges {
    pageTitle: string = "Modificar Encabezado";
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

    modHeader(): void {
        this._documentService.modMargin(this.id, this.margin).subscribe();
    }

}