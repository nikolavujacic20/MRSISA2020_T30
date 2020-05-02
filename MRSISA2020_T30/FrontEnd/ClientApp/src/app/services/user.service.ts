import { Injectable } from '@angular/core';
import { UserDto } from '../Dto/UserDto';
import { Observable } from 'rxjs';
import { Variables } from '../Variables';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {

  constructor(private http: HttpClient) {
    super();}

  register(user: UserDto): Observable<UserDto> {
    var params = JSON.stringify(user);
    return this.http.post<UserDto>(Variables.getApiEndpoint() + "api/user/register", params, this.options);


  }




}
