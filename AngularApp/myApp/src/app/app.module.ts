import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { UserMainComponent } from './users/user-main.component';
import { UserFormComponent } from './users/form/user-form.component';
import { UserModComponent } from './users/form/user-mod.component';
import { WelcomeComponent } from './home/welcome.component';
import { LoginComponent } from './login/login.component';
import { StyleMainComponent } from './style/style-main.component';
import { StyleModComponent } from './style/form/style-mod.component';
import { StyleAddComponent } from './style/form/style-add.component';


@NgModule({
  declarations: [
    AppComponent,
    UserMainComponent,
    UserFormComponent,
    UserModComponent,
    WelcomeComponent,
    LoginComponent,
    StyleMainComponent,
    StyleModComponent,
    StyleAddComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: 'style-add', component: StyleAddComponent},
      { path: 'style-mod', component: StyleModComponent},
      { path: 'style-mod/:name', component: StyleModComponent},
      { path: 'style-main', component: StyleMainComponent},
      { path: 'login', component: LoginComponent},
      { path: 'user-main', component: UserMainComponent},
      { path: 'welcome', component:  WelcomeComponent}, 
      { path: 'user-form', component: UserFormComponent},
      { path: 'user-mod', component: UserModComponent},
      { path: 'user-mod/:username', component: UserModComponent},
      { path: '', redirectTo: 'welcome', pathMatch: 'full' }, 
      { path: '**', redirectTo: 'welcome', pathMatch: 'full'} 
      ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
