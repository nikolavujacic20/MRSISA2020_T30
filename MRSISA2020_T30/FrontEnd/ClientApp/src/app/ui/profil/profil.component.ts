import { Component, OnInit } from '@angular/core';
import { ProfilService } from '../../services/profil.service';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { UserDto } from '../../Dto/UserDto';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-profil',
  templateUrl: './profil.component.html',
  styleUrls: ['./profil.component.css']
})
export class ProfilComponent implements OnInit {
  public user: UserDto = new UserDto();
  

  constructor(
    private profilService:ProfilService,
    private userService: UserService,
    private router: Router,
    private loginService:LoginService,

  ){


  }



  ngOnInit() {

    this.profilService.getById(this.loginService.getUser().id)
      .subscribe({
      next: (user: UserDto) => {
          this.user = user;
      },
        error: (ex: Error) => {
          console.log(ex.message);
        }
    })


  }

  onSubmit() {


    this.profilService.save(this.user)
      .subscribe({
        next: (user: UserDto) => {
          this.user = user;
        },
        error: (ex: Error) => {
          console.log(ex.message);
        }
      })



  }

}
