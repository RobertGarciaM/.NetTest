import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { IHistorical } from '../interfaces/IHistorical';

@Injectable({
  providedIn: 'root'
})
export class HistoricalServices {

  private readonly urlApi = environment.apiUrl;
  private readonly apiGetHistorical: string = this.urlApi + '/HistoricalLogin/GetHistorical';

  constructor(private http: HttpClient) { }

  GetHistorical(): Observable<IHistorical> {
    return this.http.post<IHistorical>(this.apiGetHistorical, null);
  }
}
