import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InterceptoTokenService implements HttpInterceptor {

  constructor() { }

  intercept( req: HttpRequest<any>, next: HttpHandler ): Observable<HttpEvent<any>> {
    let tokenStorage = '';
    debugger;
    if (sessionStorage.getItem('tokenUser') != null) {
      tokenStorage = JSON.parse(sessionStorage.getItem('tokenUser')).token;
    }

    const headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8',
      Authorization: 'Bearer ' + tokenStorage
    });

    const reqClone = req.clone({
      headers
    });

    return next.handle(reqClone).pipe(
      tap((ev: HttpEvent<any>) => {
        if (ev instanceof HttpResponse) {
          if (ev.status === 500 || ev.body.status === 500) {
            this.mensajeResponse(ev);
          }
        }
      }),
      catchError(this.mensajeError)
    );
  }

  mensajeError( error: HttpErrorResponse ) {
    console.log(error);
    // const sweetAlert: SweetAlertService = new SweetAlertService();
    // sweetAlert.Mensaje('Lo lamentamos', MensajeApplication.ErrorApplication, 'info');
    return throwError('Error personalizado');
  }

  mensajeResponse(response: HttpResponse<any>) {
    // const sweetAlert: SweetAlertService = new SweetAlertService();
    // sweetAlert.Mensaje('Lo lamentamos', MensajeApplication.ErrorApplication, 'info');
    console.log('Error en la Api', response);
  }

}
