import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { Router } from '@angular/router';
import { ExamService } from '../../services/exam.service';
import { ExamDto } from '../../Dto/ExamDto';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['./exam.component.css']
})
export class ExamComponent implements OnInit {
  exams: ExamDto[] = [];
  public now: Date = new Date();
  public korisnik = this.loginService.getUser();
  public exam: ExamDto =  new ExamDto();


  constructor(
    private loginService: LoginService,
    private router: Router,
    private examService: ExamService
  ) { }

  ngOnInit() {
    this.ucitajListu();
  }

  otkazi(id: number) {
    this.examService.otkazi(id)
      .subscribe({
        next: (exams: boolean) => {
          this.ucitajListu();
          alert("Uspesno otazan");
        },
        error: (ex: Error) => {
          console.log(ex.message);
          alert("Neuspesno otkazan");
        }
      });
  }

  ucitajListu() {
    const user = this.loginService.getUser();
    this.examService.getListById(user.id)
      .subscribe({
        next: (exams: ExamDto[]) => {
          this.exams = exams;
        },
        error: (ex: Error) => {
          console.log(ex.message);
        }
      });
  }

  show(date: string, taken: number): boolean {
    const datum = new Date(date);
    const razlika = this.now.getTime() - datum.getTime();
    if ( razlika > 0 && razlika < 86400400 || taken == 1) {
      return false;
    }
    return true;
  }

  zakazi() {
    const exam = new ExamDto();
    exam.datetime = new Date("2021-01-01 13:00:00");
    exam.locationId = 1;
    exam.pacijentId = 1;
    exam.doctorId = 1;
    exam.examType = "tip1";

    this.examService.zakazi(exam)
      .subscribe({
        next: (exams: ExamDto) => {
          this.ucitajListu();
          if (exams) {
            alert("Uspesno zakazan");
          }
          alert("Zakazivanje neuspesno");
        },
        error: (ex: Error) => {
          console.log(ex.message);
          alert("Neuspesno zakazan");
        }
      });
  }
}
