import { Component, OnInit } from '@angular/core';
import { StyleClass } from '../models/styleClass';
import { StyleClassService } from '../services/styleClass.service';

@Component({
  selector: 'styleClass-main',
  templateUrl: './styleClass-main.component.html',
})

export class StyleClassMainComponent implements OnInit {
  title = 'Style Classes';
  styleClasses: Array<StyleClass>;

  constructor(private _styleClassService: StyleClassService) {
  }

  ngOnInit(): void {
    this._styleClassService.getStyleClasses().subscribe(
      ((obtainedStyleClasses: Array<StyleClass>) => this.styleClasses = obtainedStyleClasses),
      ((error: any) => console.log(error))
    )
  }

  deleteStyleClass(id: string): void {
    this._styleClassService.deleteStyleClass(id).subscribe();
  }
}