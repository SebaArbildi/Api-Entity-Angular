import { User } from "../users/user";
import { Paragraph } from "./paragraphs/paragraph"
import { Margin } from "./margins/margin";

export class Document{
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