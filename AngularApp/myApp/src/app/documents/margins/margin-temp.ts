import { TextClass } from "../texts/text";

export class MarginTemp{
    OwnStyleClass: string;
    Texts: Array<TextClass>;
    Align: number;
    DocumentId: string;
  
    constructor(ownStyleClass : string, marginAlign : number, documentId : string){
            
            this.OwnStyleClass = ownStyleClass;
            this.Align = marginAlign;
            this.DocumentId = documentId;
            this.Texts = new Array<TextClass>();
    }
  }