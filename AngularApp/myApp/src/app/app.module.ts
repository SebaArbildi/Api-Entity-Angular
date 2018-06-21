import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { SidebarModule } from 'ng-sidebar';
import { AppComponent } from './app.component';
import { DocumentDetailComponent } from './documents/document-detail/document-detail.component';
import { DocumentFormComponent } from './documents/document-form/document-form.component';
import { DocumentModComponent } from './documents/document-form/document-mod.component';
import { DocumentMainComponent } from './documents/document-main.component';
import { FooterFormComponent } from './documents/margins/footer-form/footer-form.component';
import { FooterModComponent } from './documents/margins/footer-form/footer-mod.component';
import { FooterMainComponent } from './documents/margins/footer-main.component';
import { HeaderFormComponent } from './documents/margins/header-form/header-form.component';
import { HeaderModComponent } from './documents/margins/header-form/header-mod.component';
import { HeaderMainComponent } from './documents/margins/header-main.component';
import { ParagraphFormComponent } from './documents/paragraphs/paragraph-form/paragraph-form.component';
import { ParagraphModComponent } from './documents/paragraphs/paragraph-form/paragraph-mod.component';
import { ParagraphMainComponent } from './documents/paragraphs/paragraph-main.component';
import { TextFooterFormComponent } from './documents/texts/text-form/text-footer-form/text-footer-form.component';
import { TextFooterModComponent } from './documents/texts/text-form/text-footer-form/text-footer-mod.component';
import { TextHeaderFormComponent } from './documents/texts/text-form/text-header-form/text-header-form.component';
import { TextHeaderModComponent } from './documents/texts/text-form/text-header-form/text-header-mod.component';
import { TextParagraphFormComponent } from './documents/texts/text-form/text-paragraph-form/text-paragraph-form.component';
import { TextParagraphModComponent } from './documents/texts/text-form/text-paragraph-form/text-paragraph-mod.component';
import { TextFooterMainComponent } from './documents/texts/text-main-footer.component';
import { TextHeadernMainComponent } from './documents/texts/text-main-header.component';
import { TextParagraphMainComponent } from './documents/texts/text-main-paragraph.component';
import { WelcomeComponent } from './home/welcome.component';
import { LoginComponent } from './login/login.component';
import { SafePipe } from './safehtml.pipe';
import { StyleAddComponent } from './style/form/style-add.component';
import { StyleModComponent } from './style/form/style-mod.component';
import { StyleMainComponent } from './style/style-main.component';
import { StyleClassAddComponent } from './styleClass/form/styleClass-add.component';
import { StyleClassModComponent } from './styleClass/form/styleClass-mod.component';
import { StyleClassViewComponent } from './styleClass/form/styleClass-view.component';
import { StyleClassMainComponent } from './StyleClass/styleClass-main.component';
import { UserFormComponent } from './users/form/user-form.component';
import { UserModComponent } from './users/form/user-mod.component';
import { UserMainComponent } from './users/user-main.component';
import { UserService } from './services/user.service';
import { LoginService } from './services/login.service';
import { StyleService } from './services/style.service';
import { StyleClassService } from './services/styleClass.service';
import { DocumentService } from './services/document.service';
import { LockGuard } from './guards/lock.guard';
import { NotAvailableGuard } from './guards/notAvailable.guard';




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
    StyleClassMainComponent,
    StyleClassAddComponent,
    StyleClassModComponent,
    StyleClassViewComponent,
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
      { path: 'styleClass-view/:id', component: StyleClassViewComponent},
      { path: 'styleClass-mod', component: StyleClassModComponent},
      { path: 'styleClass-mod/:id', component: StyleClassModComponent},
      { path: 'styleClass-add', component: StyleClassAddComponent},
      { path: 'styleClass-main', component: StyleClassMainComponent, canActivate: [NotAvailableGuard]},
      { path: 'style-add', component: StyleAddComponent},
      { path: 'style-mod', component: StyleModComponent},
      { path: 'style-mod/:name', component: StyleModComponent},
      { path: 'style-main', component: StyleMainComponent, canActivate: [NotAvailableGuard]},
      { path: 'login', component: LoginComponent},
      { path: 'user-main', component: UserMainComponent, canActivate: [NotAvailableGuard]},
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
  providers: [UserService, LoginService, StyleService, StyleClassService, DocumentService, LockGuard, NotAvailableGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
