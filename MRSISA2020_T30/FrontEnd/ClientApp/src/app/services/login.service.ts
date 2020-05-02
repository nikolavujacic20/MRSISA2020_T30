import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDto } from '../Dto/UserDto';
import { Variables } from '../Variables';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient,
     @Inject('BASE_URL') private baseUrl: string) {
  }

  login(Username: string, Password: string): Observable<UserDto> {
    let httpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      'Cache-Control': 'no-cache'
    });
    let options = {
      headers: httpHeaders
    }; 
    var params = JSON.stringify({ Username, Password });
    return this.http.post<UserDto>(Variables.getApiEndpoint() + "api/user/authenticate", params, options);
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
