import { TextClass } from "../texts/text";

export class Paragraph{
    Id: string;
    OwnStyleClass: string;
    Texts: Array<TextClass>;
    Align: number;
    DocumentId: string;
  
    constructor(id : string, ownStyleClass : string, marginAlign : number, texts : Array<TextClass>, documentId : string){

            this.Id = id;
            this.OwnStyleClass = ownStyleClass;
            this.Align = marginAlign;
            this.Texts = texts;
            this.DocumentId = documentId;
    }
  }