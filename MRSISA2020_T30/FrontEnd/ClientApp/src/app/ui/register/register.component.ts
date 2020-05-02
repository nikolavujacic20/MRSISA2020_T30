import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { LoginService } from '../../services/login.service';
import { UserService } from '../../services/user.service';
import { UserDto } from '../../Dto/UserDto';

//import { AlertService UserService, AuthenticationService } from '@/_services';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;

  user: UserDto = new UserDto();

  constructor(private LoginService: LoginService, private UserService: UserService,
    private formBuilder: FormBuilder,
    private router: Router,
    //private authenticationService: AuthenticationService,
    //private userService: UserService,
    //private alertService: AlertService
  ) {
    // redirect to home if already logged in
    if (this.LoginService.getUser()) {
      this.router.navigate(['/']);
    }
  }
  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }

    this.loading = true;
    this.UserService.register(this.user)
      .pipe(first())
      .subscribe(
        data => {
          console.log("Registration succesfull:");
          this.router.navigate(['/login']);
        },
        error => {
          console.log("I fuked up:");
          this.loading = false;
        });
  }



}
