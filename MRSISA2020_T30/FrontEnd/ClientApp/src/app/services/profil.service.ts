import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Variables } from '../Variables';
import { UserDto } from '../Dto/UserDto';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfilService extends BaseService {
  private http;

  constructor(client: HttpClient) {
    super();
    this.http = client;
    






  }


  save(user:UserDto) {


    return this.http.post(Variables.getApiEndpoint() + "api/user", JSON.stringify(user), this.options);

  }

  getById(id: number):Observable<UserDto> {


    return this.http.get(Variables.getApiEndpoint() + "api/user/" + id);

  }
}
