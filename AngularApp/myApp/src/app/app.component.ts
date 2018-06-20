import { Component } from '@angular/core';
import  { UserService } from './services/user.service'; 
import { DocumentService } from './services/document.service';
import  { LoginService } from './services/login.service'; 
import  { StyleService } from './services/style.service'; 
import  { StyleClassService } from './services/styleClass.service'; 


@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  providers: [UserService, LoginService, StyleService, StyleClassService, DocumentService]
})
export class AppComponent {
  title = 'Obligatorio';
}
