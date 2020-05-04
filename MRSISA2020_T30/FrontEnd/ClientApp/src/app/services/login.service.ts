import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDto } from '../Dto/UserDto';
import { Variables } from '../Variables';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  login(Username: string, Password: string): Observable<UserDto> {
 
    var params = JSON.stringify({ Username, Password });
    return this.http.post<UserDto>(Variables.getApiEndpoint() + "api/user/authenticate", params, this.options);
  }

  saveUser(user: UserDto) {
    sessionStorage.setItem("user", JSON.stringify(user));
  }

  getUser(): UserDto {
    return JSON.parse(sessionStorage.getItem("user"));
  }

  deleteUser() {
    sessionStorage.removeItem("user");
  }
}
