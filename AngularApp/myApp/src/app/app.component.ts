import { Component } from '@angular/core';
import  { UserService } from './users/user.service'; 
import { DocumentService } from './documents/document.service';


@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  providers: [UserService, DocumentService] 
})
export class AppComponent {
  title = 'Obligatorio';
}
