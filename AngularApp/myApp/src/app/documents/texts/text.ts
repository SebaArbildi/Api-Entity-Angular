export class TextClass{
    Id: string;
    TextContent: string;
    OwnStyleClass: string;
    BodyId: string;
  
    constructor(id : string, ownStyleClass : string, textContent : string, bodyId : string){

            this.Id = id;
            this.TextContent = textContent;
            this.OwnStyleClass = ownStyleClass;
            this.BodyId = bodyId;
    }
  }