import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { UserMainComponent } from './users/user-main.component';
import { UserFormComponent } from './users/form/user-form.component';
import { WelcomeComponent } from './home/welcome.component';
import { DocumentMainComponent } from './documents/document-main.component';
import { DocumentDetailComponent } from './documents/document-detail/document-detail.component';
import { SidebarModule } from 'ng-sidebar';
import { SafePipe } from './safehtml.pipe';
import { DocumentFormComponent } from './documents/document-form/document-form.component';
import { DocumentModComponent } from './documents/document-form/document-mod.component';


@NgModule({
  declarations: [
    AppComponent,
    DocumentFormComponent,
    DocumentModComponent,
    UserMainComponent,
    UserFormComponent,
    SafePipe,
    DocumentMainComponent,
    DocumentDetailComponent,
    WelcomeComponent
  ],
  imports: [
    BrowserModule,
    SidebarModule.forRoot(),
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: 'user-main', component: UserMainComponent},
      { path: 'document-main', component: DocumentMainComponent},
      { path: 'document-detail/:id', component: DocumentDetailComponent},
      { path: 'welcome', component:  WelcomeComponent},
      { path: 'document-form', component: DocumentFormComponent},
      { path: 'document-mod/:id', component: DocumentModComponent},
      { path: 'user-form', component: UserFormComponent},
      { path: '', redirectTo: 'welcome', pathMatch: 'full' }, 
      { path: '**', redirectTo: 'welcome', pathMatch: 'full'} 
      ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
