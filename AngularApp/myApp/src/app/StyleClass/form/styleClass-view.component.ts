import { Component } from '@angular/core';
import { Style } from '../../models/style';
import { StyleService } from '../../services/style.service';
import { ActivatedRoute } from '@angular/router';
import { StyleClass } from '../../models/styleClass';
import { StyleClassService } from '../../services/styleClass.service';
import { forEach } from '@angular/router/src/utils/collection';



@Component({
    selector: 'styleClass-view',
    templateUrl: './styleClass-view.component.html'
})
export class StyleClassViewComponent {
    styleClass: StyleClass;
    pageTitle: string = "Detalle";

    constructor(private _styleClassService: StyleClassService, route: ActivatedRoute) {
        this.styleClass = new StyleClass("", "",[], null);
        this.styleClass.Id = route.snapshot.params['id'];
    }

    ngOnInit(): void {
        this._styleClassService.getStyleClass(this.styleClass.Id).subscribe(
            ((obtainedStyleClass: StyleClass) => this.styleClass = obtainedStyleClass),
            ((error: any) => console.log(error))
        )
    }

    ngOnChanges(): void {
        this._styleClassService.getStyleClass(this.styleClass.Id).subscribe(
            ((obtainedStyleClass: StyleClass) => this.styleClass = obtainedStyleClass),
            ((error: any) => console.log(error))
        )
    }
}