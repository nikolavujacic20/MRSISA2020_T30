import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { UserDto } from '../../Dto/UserDto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public username: string;
  public password: string;

  constructor(private loginService: LoginService,
    private router: Router) { }


  ngOnInit() {
  }

  submit() {
    this.loginService.login(this.username, this.password)
      .subscribe({
        next: (user: UserDto) => {
          this.loginService.saveUser(user);
          this.router.navigate(["/"]);
        },
        error: (ex: Error) => {
          console.log(ex.message);
        } 
      })
  }

}
