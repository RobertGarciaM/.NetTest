import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public nombreUsuario: string;
  public edad: string;
  public genero: string;
  public nacionalidad: string;
  public rol: string;
  public esAdmin = false;
  constructor(private router: Router) { }

  ngOnInit() {
    if (sessionStorage.getItem('role') === '"Admin"') {
      this.esAdmin = true;
    } else {
      this.esAdmin = false;
    }

    this.nombreUsuario = sessionStorage.getItem('NameComplet');
    this.edad = sessionStorage.getItem('Age');
    this.genero = sessionStorage.getItem('Gender');
    this.nacionalidad = sessionStorage.getItem('National');
    this.rol = sessionStorage.getItem('role');
  }

  gotoHistory() {
    this.router.navigate(['/historical']);
  }

  goReserve() {
    this.router.navigate(['/products']);
  }

  goUsers() {
    this.router.navigate(['/users']);
  }

  viewReserve() {
    this.router.navigate(['/reserveview']);
  }

}
