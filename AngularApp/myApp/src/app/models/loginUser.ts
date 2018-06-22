export class LoginUser {
  Name: string;
  LastName: string;
  Username: string;
  Password: string;
  Mail: string;
  IsAdmin: boolean;
  Token: string;

  constructor(Name: string, LastName: string, Username: string, Password: string, Mail: string, IsAdmin: boolean, Token: string) {
    this.Name = Name;
    this.LastName = LastName;
    this.Username = Username;
    this.Password = Password;
    this.Mail = Mail;
    this.IsAdmin = IsAdmin;
    this.Token = Token;
  }
}