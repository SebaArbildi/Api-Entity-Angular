import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { UserMainComponent } from './users/user-main.component';
import { UserFormComponent } from './users/form/user-form.component';
import { WelcomeComponent } from './home/welcome.component';


@NgModule({
  declarations: [
    AppComponent,
    UserMainComponent,
    UserFormComponent,
    WelcomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: 'user-main', component: UserMainComponent},
      { path: 'welcome', component:  WelcomeComponent}, 
      { path: 'user-form', component: UserFormComponent},
      { path: '', redirectTo: 'welcome', pathMatch: 'full' }, 
      { path: '**', redirectTo: 'welcome', pathMatch: 'full'} 
      ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
