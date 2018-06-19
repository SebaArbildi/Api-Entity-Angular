import { Style } from './style';

export class StyleClass {
    Id: string;
    Name: string;
    ProperStyles: Array<Style>;
    InheritedStyleClass: StyleClass;

    constructor(Id: string, Name: string, ProperStyles: Array<Style>, InheritedStyleClass: StyleClass) {
        this.Id = Id;
        this.Name = Name;
        this.ProperStyles = ProperStyles;
        this.InheritedStyleClass = InheritedStyleClass;
    }
}