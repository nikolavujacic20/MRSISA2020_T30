import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UiModule } from './ui/ui.module';
import { LoginComponent } from './ui/login/login.component';
import { TokenInterceptor } from './interceptors/token-interceptor';
import { RegisterComponent } from './ui/register/register.component';
import { ProfilComponent } from './ui/profil/profil.component';
import { ExamComponent } from './ui/exam/exam.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'profil', component:ProfilComponent},
      { path: 'register', component: RegisterComponent },
      { path: 'exam', component: ExamComponent }
    ]),
    UiModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
