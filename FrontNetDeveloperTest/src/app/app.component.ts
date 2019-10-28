import { Component, OnInit, HostListener, OnDestroy } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from './pages/auth-service/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [AuthService]
})
export class AppComponent implements OnInit {
  title = 'FrontNetDeveloperTest';
  public isAuthenticated: boolean;
  userInactive: Subject<any> = new Subject();
  userActivity;
  public validarRecuperar = true;

  constructor(private authService: AuthService, private router: Router
    // ,
    // private sweetAlert: SweetAlertService
    ) {
  }

  ngOnInit() {
    this.validarUsuario();
  }

  userLogueado(event) {
    this.validarUsuario();
  }

  validarUsuario() {
    this.authService.isAuthenticate().subscribe(subs => {
      this.isAuthenticated = subs;
    });
  }

  cerrarSesion(): void {
    this.validarRecuperar = false;
    this.authService.AuthenticateOut();
    this.validarUsuario();
  }

}
