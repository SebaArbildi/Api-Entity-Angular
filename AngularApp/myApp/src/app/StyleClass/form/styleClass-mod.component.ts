import { Component } from '@angular/core';
import { Style } from '../../models/style';
import { StyleService } from '../../services/style.service';
import { ActivatedRoute } from '@angular/router';
import { StyleClass } from '../../models/styleClass';
import { StyleClassService } from '../../services/styleClass.service';
import { forEach } from '@angular/router/src/utils/collection';



@Component({
    selector: 'styleClass-mod',
    templateUrl: './styleClass-mod.component.html'
})
export class StyleClassModComponent {
    pageTitle: string = "Mod StyleClass";
    styles: Array<Style>;
    styleClass: StyleClass;

    constructor(private _styleService: StyleService, private _styleClassService: StyleClassService, route: ActivatedRoute) {
        this.styleClass = new StyleClass("", "",[], null);
        this.styleClass.Id = route.snapshot.params['id'];
    }

    ngOnInit(): void {
        this._styleService.getStyles().subscribe(
            ((obtainedStyles: Array<Style>) => this.styles = obtainedStyles),
            ((error: any) => console.log(error))
        )

        this._styleClassService.getStyleClass(this.styleClass.Id).subscribe(
            ((obtainedStyleClass: StyleClass) => this.styleClass = obtainedStyleClass),
            ((error: any) => console.log(error))
        )
    }

    addStyle(style: Style): void {
        this._styleClassService.addStylesToStyleClass(this.styleClass.Id, style).subscribe()
    }

    deleteStyle(style: Style): void {
        this._styleClassService.deleteStyleFromStyleClass(this.styleClass.Id, style.Name).subscribe()
    }


}