import { Component, OnInit } from '@angular/core';
import { Style } from '../models/style';
import { StyleService } from '../services/style.service';

@Component({
  selector: 'style-main',
  templateUrl: './style-main.component.html',
})

export class StyleMainComponent implements OnInit {
  title = 'Estilos';
  styles: Array<Style>;

  constructor(private _styleService: StyleService) {
  }

  ngOnInit(): void {
    this._styleService.getStyles().subscribe(
      ((obtainedStyles: Array<Style>) => this.styles = obtainedStyles),
      ((error: any) => console.log(error))
    )
  }

  ngOnChanges(): void {
    this._styleService.getStyles().subscribe(
      ((obtainedStyles: Array<Style>) => this.styles = obtainedStyles),
      ((error: any) => console.log(error))
    )
    window.location.reload();
  }

  deleteStyle(name: string): void {
    if (window.confirm('¿Esta seguro que desea eliminar el estilo?')) {
      this._styleService.deleteStyle(name).subscribe();
      alert("Estilo eliminado");
      window.location.reload();
    }
  }
}