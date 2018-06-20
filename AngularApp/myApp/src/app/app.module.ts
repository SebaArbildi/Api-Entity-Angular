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
import { DocumentMainComponent } from './documents/document-main.component';
import { DocumentDetailComponent } from './documents/document-detail/document-detail.component';
import { SidebarModule } from 'ng-sidebar';
import { SafePipe } from './safehtml.pipe';
import { DocumentFormComponent } from './documents/document-form/document-form.component';
import { DocumentModComponent } from './documents/document-form/document-mod.component';
import { HeaderMainComponent } from './documents/margins/header-main.component';
import { ParagraphMainComponent } from './documents/paragraphs/paragraph-main.component';
import { FooterMainComponent } from './documents/margins/footer-main.component';
import { TextHeadernMainComponent } from './documents/texts/text-main-header.component';
import { HeaderFormComponent } from './documents/margins/header-form/header-form.component';
import { HeaderModComponent } from './documents/margins/header-form/header-mod.component';
import { FooterFormComponent } from './documents/margins/footer-form/footer-form.component';
import { FooterModComponent } from './documents/margins/footer-form/footer-mod.component';
import { TextFooterMainComponent } from './documents/texts/text-main-footer.component';
import { TextParagraphMainComponent } from './documents/texts/text-main-paragraph.component';
import { ParagraphFormComponent } from './documents/paragraphs/paragraph-form/paragraph-form.component';
import { ParagraphModComponent } from './documents/paragraphs/paragraph-form/paragraph-mod.component';
import { TextFooterFormComponent } from './documents/texts/text-form/text-footer-form/text-footer-form.component';
import { TextFooterModComponent } from './documents/texts/text-form/text-footer-form/text-footer-mod.component';
import { TextHeaderFormComponent } from './documents/texts/text-form/text-header-form/text-header-form.component';
import { TextHeaderModComponent } from './documents/texts/text-form/text-header-form/text-header-mod.component';
import { TextParagraphFormComponent } from './documents/texts/text-form/text-paragraph-form/text-paragraph-form.component';
import { TextParagraphModComponent } from './documents/texts/text-form/text-paragraph-form/text-paragraph-mod.component';


@NgModule({
  declarations: [
    AppComponent,
    DocumentFormComponent,
    DocumentModComponent,
    UserMainComponent,
    UserFormComponent,
    UserModComponent,
    WelcomeComponent,
    LoginComponent,
    StyleMainComponent,
    StyleModComponent,
    StyleAddComponent,
    HeaderMainComponent,
    HeaderFormComponent,
    HeaderModComponent,
    ParagraphMainComponent,
    ParagraphFormComponent,
    ParagraphModComponent,
    FooterMainComponent,
    FooterFormComponent,
    FooterModComponent,
    TextHeadernMainComponent,
    TextHeaderFormComponent,
    TextHeaderModComponent,
    TextFooterMainComponent,
    TextFooterFormComponent,
    TextFooterModComponent,
    TextParagraphMainComponent,
    TextParagraphFormComponent,
    TextParagraphModComponent,
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
      { path: 'style-add', component: StyleAddComponent },
      { path: 'style-mod', component: StyleModComponent },
      { path: 'style-mod/:name', component: StyleModComponent },
      { path: 'style-main', component: StyleMainComponent },
      { path: 'login', component: LoginComponent },
      { path: 'user-main', component: UserMainComponent },
      { path: 'header-main/:id', component: HeaderMainComponent },
      { path: 'header-form/:id', component: HeaderFormComponent },
      { path: 'header-mod/:id/:marginId', component: HeaderModComponent },
      { path: 'footer-form/:id', component: FooterFormComponent },
      { path: 'footer-mod/:id/:marginId', component: FooterModComponent },
      { path: 'footer-main/:id', component: FooterMainComponent },
      { path: 'paragraph-main/:id', component: ParagraphMainComponent },
      { path: 'paragraph-form/:id', component: ParagraphFormComponent },
      { path: 'paragraph-mod/:id/:paragraphId', component: ParagraphModComponent },
      { path: 'text-main-header/:id/:marginId', component: TextHeadernMainComponent },
      { path: 'text-header-form/:id/:marginId', component: TextHeaderFormComponent },
      { path: 'text-header-mod/:id/:marginId/:textId', component: TextHeaderModComponent },
      { path: 'text-main-footer/:id/:marginId', component: TextFooterMainComponent },
      { path: 'text-footer-form/:id/:marginId', component: TextFooterFormComponent },
      { path: 'text-footer-mod/:id/:marginId/:textId', component: TextFooterModComponent },
      { path: 'text-main-paragraph/:id/:paragraphId', component: TextParagraphMainComponent },
      { path: 'text-paragraph-form/:id/:paragraphId', component: TextParagraphFormComponent },
      { path: 'text-paragraph-mod/:id/:paragraphId/:textId', component: TextParagraphModComponent },
      { path: 'document-main', component: DocumentMainComponent },
      { path: 'document-detail/:id', component: DocumentDetailComponent },
      { path: 'welcome', component: WelcomeComponent },
      { path: 'document-form', component: DocumentFormComponent },
      { path: 'document-mod/:id', component: DocumentModComponent },
      { path: 'user-form', component: UserFormComponent },
      { path: 'user-mod', component: UserModComponent },
      { path: 'user-mod/:username', component: UserModComponent },
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      { path: '**', redirectTo: 'welcome', pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
