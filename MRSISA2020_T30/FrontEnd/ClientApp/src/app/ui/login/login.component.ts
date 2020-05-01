import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../../services/login.service';
import { UserDto } from '../../Dto/UserDto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public username: string;
  public password: string;

  constructor(private loginService: LoginService) { }


  ngOnInit() {
    this.username = "alsdlas";
  }

  submit() {
    this.loginService.login(this.username, this.password)
      .subscribe({
        next: (user: UserDto) => {
          this.loginService.saveUser(user);
        },
        error: (ex: Error) => {
          console.log(ex.message);
        } 
      })
  }

}
