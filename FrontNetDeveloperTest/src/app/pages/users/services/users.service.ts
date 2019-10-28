import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { IUsers, Users } from '../interfaces/IUsers';

@Injectable({
  providedIn: 'root'
})
export class UserServices {

  private readonly urlApi = environment.apiUrl;
  private readonly apiGetUsers: string = this.urlApi + '/ManagementUsers/GetUsers';
  private readonly apiSetUSer: string = this.urlApi + '/ManagementUsers/Register';
  private readonly apiDeleteLogic: string = this.urlApi + '/ManagementUsers/DeleteLogic';

  constructor(private http: HttpClient) { }

  GetUsers(): Observable<IUsers> {
    return this.http.post<IUsers>(this.apiGetUsers, null);
  }

  SetUser(user: Users): Observable<IUsers> {
    return this.http.post<IUsers>(this.apiSetUSer, user);
  }

  DeleteLogic(user: Users): Observable<IUsers> {
    return this.http.post<IUsers>(this.apiDeleteLogic, user);
  }
}
