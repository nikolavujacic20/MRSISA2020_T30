import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { ProfilComponent } from './profil/profil.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { ExamComponent } from './exam/exam.component';




@NgModule({
  declarations: [LoginComponent, RegisterComponent, ProfilComponent, ScheduleComponent, ExamComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class UiModule { }
