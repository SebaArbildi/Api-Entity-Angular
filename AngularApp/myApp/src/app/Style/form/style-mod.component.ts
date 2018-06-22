import { Component } from '@angular/core';
import { Style } from '../../models/style';
import { StyleService } from '../../services/style.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'style-mod',
    templateUrl: './style-mod.component.html'
})
export class StyleModComponent {
    pageTitle: string = "Mod Style";
    name: string;
    selectedOption: string;
    style: Style;

    constructor(private _styleService: StyleService, route: ActivatedRoute) {
        this.style = new Style("","","");
        this.name = route.snapshot.params['name'];
        this.style.Name = this.name;
    }

    capture(): void{
        this.style.Type = this.selectedOption;
    }

    ngOnInit(): void {
        this._styleService.getStyle(this.style.Name).subscribe(
            ((obtainedStyle: Style) => this.style = obtainedStyle),
            ((error: any) => console.log(error))
        )
    }

    ngOnChanges(): void {
        this._styleService.getStyle(this.style.Name).subscribe(
            ((obtainedStyle: Style) => this.style = obtainedStyle),
            ((error: any) => console.log(error))
        )
    }

    modStyle(): void{
        this._styleService.modStyle(this.name, this.style).subscribe(
            ((error: any) => console.log(error))
        )
        alert("Estilo modificado");
        window.location.reload();
    }

}