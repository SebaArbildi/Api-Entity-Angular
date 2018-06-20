import { User } from "../models/user";
import { Paragraph } from "../documents/paragraphs/paragraph"
import { Margin } from "../documents/margins/margin";

export class UserDocument{
    Id: string;
    CreatorUser: User;
    Title: string;
    CreationDate: String;
    LastModifyDate: String;
    OwnStyleClass: string;
    DocumentMargins: Array<Margin>;
    DocumentParagraphs: Array<Paragraph>;
  
    constructor(id : string, creatorUser: User, title : string, creationDate : Date, lastModifyDate : Date
        , ownStyleClass : string, documentMargins : Array<Margin>, documentParagraphs : Array<Paragraph>){

            this.Id = id;
            this.CreatorUser = creatorUser;
            this.Title = title;
            this.CreationDate = creationDate.toLocaleDateString();
            this.LastModifyDate = lastModifyDate.toLocaleDateString();
            this.OwnStyleClass = ownStyleClass;
            this.DocumentMargins = documentMargins;
            this.DocumentParagraphs = documentParagraphs;
    }
    
  }