import { Component, OnInit } from '@angular/core';
import { StyleClass } from '../models/styleClass';
import { StyleClassService } from '../services/styleClass.service';

@Component({
  selector: 'styleClass-main',
  templateUrl: './styleClass-main.component.html',
})

export class StyleClassMainComponent implements OnInit {
  title = 'Clases de estilo';
  styleClasses: Array<StyleClass>;

  constructor(private _styleClassService: StyleClassService) {
  }

  ngOnInit(): void {
    this._styleClassService.getStyleClasses().subscribe(
      ((obtainedStyleClasses: Array<StyleClass>) => this.styleClasses = obtainedStyleClasses),
      ((error: any) => console.log(error))
    )
  }

  ngOnChanges(): void {
    this._styleClassService.getStyleClasses().subscribe(
      ((obtainedStyleClasses: Array<StyleClass>) => this.styleClasses = obtainedStyleClasses),
      ((error: any) => console.log(error))
    )
    window.location.reload();
  }

  deleteStyleClass(id: string): void {
    if (window.confirm('¿Esta seguro que desea eliminar el estilo?')) {
      this._styleClassService.deleteStyleClass(id).subscribe();
      alert("Clase de estilo eliminada");
      window.location.reload();
    }
  }
}