import { Margin } from "./margins/margin";
import { Paragraph } from "./paragraphs/paragraph";

export class DocumentTemp{
    Title: string;
    OwnStyleClass: string;
    DocumentMargins: Array<Margin>;
    DocumentParagraphs: Array<Paragraph>;
  
    constructor(title : string, ownStyleClass : string){
            this.Title = title;
            this.OwnStyleClass = ownStyleClass;
            this.DocumentMargins = new Array<Margin>();
            this.DocumentParagraphs = new Array<Paragraph>();
    }
    
  }