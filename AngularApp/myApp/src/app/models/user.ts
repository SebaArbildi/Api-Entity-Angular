export class User{
    Name: string;
    LastName: string;
    Username: string;
    Password: string;
    Mail: string;
    IsAdmin: boolean;
  
    constructor(Name: string, LastName: string, Username:string, Password:string, Mail:string, IsAdmin:boolean){
      this.Name = Name;
      this.LastName = LastName;
      this.Username = Username;
      this.Password = Password;
      this.Mail = Mail;
      this.IsAdmin = IsAdmin;
    }
  }