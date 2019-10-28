import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ILogin } from './interfaces/iLogin';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginAppService {

  private readonly urlApi = environment.apiUrl;
  private readonly apiSetLogin: string = this.urlApi + '/ApplicationUser/Login';

  constructor(private http: HttpClient) { }

  setLoginUser(login: ILogin): Observable<any> {
    return this.http.post<any>(this.apiSetLogin, login);
  }
}
