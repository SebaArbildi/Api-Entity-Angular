export class TextClass{
    Id: string;
    OwnStyleClass: string;
    TextContent: string;
    BodyId: string;
  
    constructor(id : string, ownStyleClass : string, textContent : string, bodyId : string){

            this.Id = id;
            this.TextContent = textContent;
            this.OwnStyleClass = ownStyleClass;
            this.BodyId = bodyId;
    }
  }