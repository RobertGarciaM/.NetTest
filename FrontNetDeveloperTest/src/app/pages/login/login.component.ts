import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { ILogin } from './interfaces/iLogin';
import jwt_decode from 'jwt-decode';
import { AuthService } from '../auth-service/auth.service';
import { LoginAppService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [LoginAppService]
})
export class LoginComponent implements OnInit {

  public images = [1, 2, 3].map(() => 'https://picsum.photos/900/500?random&t=${Math.random()}');
  public login: ILogin = { userName: '', password: '' };
  public textoErrorLogin = '';
  public recuperarPassword = false;
  private tokenChangePassword = undefined;
  public changePassword = false;
  public sedes = [];
  @Output() loginUser = new EventEmitter<boolean>();
  @Input() recuperarContrasena = false;
  public userNameRecuperar = '';

  constructor(
    private loginService: LoginAppService,
    private authService: AuthService
    // ,
    // private sweetAlert: SweetAlertService
    ) { }

  ngOnInit() {
    this.validarRecuperarPassword();
  }

  validarRecuperarPassword() {
    const url = window.location.href;
    // Vamos a validar si el usuario tiene un token para recuperar contraseña
    if (url.length > 46 && this.recuperarContrasena === true) {
      this.tokenChangePassword = url.split( 'token:', 2 )[1];
      if (this.tokenChangePassword !== undefined) {
        this.changePassword = true;
      }
    }
  }


  async setLogin( form ) {
    form.submitted = false;
    this.loguearUsuario();
  }

  async loguearUsuario() {
    await this.loginService.setLoginUser( this.login ).subscribe(response => {
      if ( response.status === 200) {
          console.log(jwt_decode(JSON.stringify(response.data)), 'JWT Decode');
          sessionStorage.setItem('tokenUser', JSON.stringify(response.data));
          sessionStorage.setItem('role', JSON.stringify(jwt_decode(JSON.stringify(response.data)).role));
          sessionStorage.setItem('Name', JSON.stringify(jwt_decode(JSON.stringify(response.data)).unique_name));
          sessionStorage.setItem('Age', JSON.stringify(jwt_decode(JSON.stringify(response.data)).Age));
          sessionStorage.setItem('National', JSON.stringify(jwt_decode(JSON.stringify(response.data)).National));
          sessionStorage.setItem('Gender', JSON.stringify(jwt_decode(JSON.stringify(response.data)).Gender));
          sessionStorage.setItem('NameComplet', JSON.stringify(jwt_decode(JSON.stringify(response.data)).NameComplet));
          this.loginUser.emit(true);
      } else {
        // this.sweetAlert.Mensaje('Alerta', MensajeApplication.notLogin, 'warning');
      }
    });
  }

  changeEstadoRecuperar() {
    this.recuperarPassword = !this.recuperarPassword;
  }

  changeEstadoChange() {
    this.changePassword = false;
    this.recuperarPassword = false;
  }

}
