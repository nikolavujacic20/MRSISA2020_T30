import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { ExamDto } from '../Dto/ExamDto';
import { Observable } from 'rxjs';
import { Variables } from '../Variables';

@Injectable({
  providedIn: 'root'
})
export class ExamService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  getById(id: number): Observable<ExamDto> {
    return this.http.get<ExamDto>(Variables.getApiEndpoint() + `api/exam/${id}`, this.options);
  }

  getListById(pacijentId: number): Observable<ExamDto[]> {
    return this.http.get<ExamDto[]>(Variables.getApiEndpoint() + `api/exam/list/${pacijentId}`, this.options);
  }

  zakazi(exam: ExamDto): Observable<ExamDto> {
    let params = JSON.stringify(exam);
    return this.http.post<ExamDto>(Variables.getApiEndpoint() + `api/exam/zakazi`, params, this.options);
  }

  otkazi(id: number): Observable<boolean> {
    return this.http.delete<boolean>(Variables.getApiEndpoint() + `api/exam/${id}`, this.options);
  }
}
