import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { IProducts, Products } from '../interfaces/IProducts';


@Injectable({
  providedIn: 'root'
})
export class ProductsServices {

  private readonly urlApi = environment.apiUrl;
  private readonly apiGetHistorical: string = this.urlApi + '/Products/GetProducts';
  private readonly apiReserveProducts: string = this.urlApi + '/Products/ReserveProducts';

  constructor(private http: HttpClient) { }

  GetProducts(): Observable<IProducts> {
    return this.http.post<IProducts>(this.apiGetHistorical, null);
  }

  RserverProducts(item: Products): Observable<IProducts> {
    return this.http.post<IProducts>(this.apiReserveProducts, item);
  }
}
