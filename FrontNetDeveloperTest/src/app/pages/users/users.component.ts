import { Component, OnInit } from '@angular/core';
import { UserServices } from './services/users.service';
import { Users } from './interfaces/IUsers';


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  public users: Users[];
  constructor(private userService: UserServices) { }

  ngOnInit() {
   this.getUser();
  }

  getUser(){
    if (sessionStorage.getItem('role') === '"Admin"') {
      this.userService.GetUsers().subscribe(response => {
        if ( response.status === 200) {
          console.log('Usuarios del sistema', response.data)
          this.users = response.data;
        }
      });
    }
  }

  addUser() {
    const user: Users = {
      userName: '',
      nombreCompleto: null,
      edad: null,
      genero: null,
      nacionalidad: null,
      rol: '',
    };

    this.users.unshift(user);
  }

  saveUser(item: Users) {
    if (item.rol === 'Admin' || item.rol === 'Regular') {
      this.userService.SetUser(item).subscribe(response => {
        if ( response.status === 200) {
          this.getUser();
        }
      });
    }
  }

  deleteUser(item: Users) {
    this.userService.DeleteLogic(item).subscribe(response => {
      if ( response.status === 200) {
        this.getUser();
      }
    });
  }
}
