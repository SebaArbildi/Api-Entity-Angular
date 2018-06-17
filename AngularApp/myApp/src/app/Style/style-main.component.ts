import { Component, OnInit } from '@angular/core';
import { Style } from '../models/style';
import { StyleService } from '../services/style.service';

@Component({
  selector: 'style-main',
  templateUrl: './style-main.component.html',
})

export class StyleMainComponent implements OnInit {
  title = 'Styles';
  styles: Array<Style>;

  constructor(private _styleService: StyleService) {
  }

  ngOnInit(): void {
    this._styleService.getStyles().subscribe(
      ((obtainedStyles: Array<Style>) => this.styles = obtainedStyles),
      ((error: any) => console.log(error))
    )
  }

  deleteStyle(name:string): void{
    this._styleService.deleteStyle(name).subscribe();
  }
}