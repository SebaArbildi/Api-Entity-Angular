import { Component } from '@angular/core';
import { Style } from '../../models/style';
import { StyleService } from '../../services/style.service';
import { ActivatedRoute } from '@angular/router';
import { StyleClass } from '../../models/styleClass';
import { StyleClassService } from '../../services/styleClass.service';
import { forEach } from '@angular/router/src/utils/collection';



@Component({
    selector: 'styleClass-add',
    templateUrl: './styleClass-add.component.html'
})
export class StyleClassAddComponent {
    pageTitle: string = "Add StyleClass";
    styles: Array<Style>;
    styleClass: StyleClass;
    styleClasses: Array<StyleClass>;
    stylesToAdd: Array<Style>;
    styleClassToAdd: StyleClass;

    constructor(private _styleService: StyleService, private _styleClassService: StyleClassService) {
        this.styleClass = new StyleClass("", "",[], null);
        this.stylesToAdd = [];
        this.styleClassToAdd = null;
    }

    ngOnInit(): void {
        this._styleService.getStyles().subscribe(
            ((obtainedStyles: Array<Style>) => this.styles = obtainedStyles),
            ((error: any) => console.log(error))
        )

        this._styleClassService.getStyleClasses().subscribe(
            ((obtainedStyleClasses: Array<StyleClass>) => this.styleClasses = obtainedStyleClasses),
            ((error: any) => console.log(error))
        )
    }

    addStyle(style: Style): void {
        this.stylesToAdd.push(style);
        alert("Estilo añadido a la clase de estilo");
    }

    addInheritedStyleClass(inheritedStyleClass: StyleClass): void {
        this.styleClassToAdd = inheritedStyleClass;
        this.styleClass.InheritedStyleClass = this.styleClassToAdd;
        alert("Clase de estilo heredada añadida a la clase de estilo");
    }

    addStyleClass(): void {
        console.log("primero");

        this._styleClassService.addStyleClass(this.styleClass).subscribe(
            ((error: any) => console.log(error))
        )
        console.log("segundo");
        this.styles.forEach(style => this._styleClassService.addStylesToStyleClass(this.styleClass.Id, style).subscribe());
        
        alert("Clase de estilo añadida");

        window.location.reload();
    }

}