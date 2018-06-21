import { Component } from '@angular/core';
import { UserService } from './services/user.service';
import { DocumentService } from './services/document.service';
import { LoginService } from './services/login.service';
import { StyleService } from './services/style.service';
import { StyleClassService } from './services/styleClass.service';
import { LockGuard } from './guards/lock.guard';
import { NotAvailableGuard } from './guards/notAvailable.guard';


@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  providers: [UserService, LoginService, StyleService, StyleClassService, DocumentService, LockGuard, NotAvailableGuard]
})
export class AppComponent {
  title = 'SGD';

  logOut() {
    if (localStorage.getItem('userToken')) {
      if (window.confirm('¿Seguro desea deslogearse?')) {
        localStorage.clear();
        window.location.assign("/login");
      }
    }
    else{
      alert("No estas logeado!");
    }
  }
}
