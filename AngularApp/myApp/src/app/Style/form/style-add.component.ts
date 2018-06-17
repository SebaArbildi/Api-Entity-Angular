import { Component } from '@angular/core';
import { Style } from '../../models/style';
import { StyleService } from '../../services/style.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'style-add',
    templateUrl: './style-add.component.html'
})
export class StyleAddComponent {
    pageTitle: string = "Add Style";
    name: string;
    selectedOption: string;
    style: Style;

    constructor(private _styleService: StyleService) {
        this.style = new Style("","","");
    }

    capture(): void{
        this.style.Type = this.selectedOption;
    }

    addStyle(): void{
        this._styleService.addStyle(this.style).subscribe(
            ((error: any) => console.log(error))
        )
    }

}