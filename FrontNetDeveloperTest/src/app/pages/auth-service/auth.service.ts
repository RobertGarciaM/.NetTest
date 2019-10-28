import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  jwtHelper: JwtHelperService;

  constructor() {
    this.jwtHelper = new JwtHelperService();
  }

  // Este metodo devuelve el valor de la expiración del token, en caso de no encontrarse un token en el storage devuelte false
  public isAuthenticate(): Observable<boolean> {
    if (sessionStorage.getItem('tokenUser') !== null && sessionStorage.getItem('tokenUser') !== undefined) {
      return new Observable<boolean>(observ => {
        observ.next(!this.jwtHelper.isTokenExpired(sessionStorage.getItem('tokenUser')));
      });
    }

    return new Observable<boolean>(observ => {
      observ.next(false);
    });
  }

  public AuthenticateOut(): void {
    sessionStorage.clear();
  }
}
