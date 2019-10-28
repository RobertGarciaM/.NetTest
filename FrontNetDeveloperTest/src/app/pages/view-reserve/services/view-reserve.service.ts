import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { IReserva } from '../interfaces/IReserve';


@Injectable({
  providedIn: 'root'
})
export class ViewReserveServices {

  private readonly urlApi = environment.apiUrl;
  private readonly apiGetReserve: string = this.urlApi + '/Products/GetReserve';

  constructor(private http: HttpClient) { }

  GetReserve(): Observable<IReserva> {
    return this.http.post<IReserva>(this.apiGetReserve, null);
  }
}
