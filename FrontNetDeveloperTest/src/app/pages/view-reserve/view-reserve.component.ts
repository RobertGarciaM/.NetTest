import { Component, OnInit } from '@angular/core';
import { ViewReserveServices } from './services/view-reserve.service';
import { Reservas } from './interfaces/IReserve';

@Component({
  selector: 'app-view-reserve',
  templateUrl: './view-reserve.component.html',
  styleUrls: ['./view-reserve.component.css']
})
export class ViewReserveComponent implements OnInit {
  public reserve: Reservas[];
  constructor(private viewReserveServices: ViewReserveServices) { }

  ngOnInit() {
    this.viewReserveServices.GetReserve().subscribe(response => {
      if ( response.status === 200) {
        console.log( response.data, 'reservas');
        this.reserve = response.data;
      }
    });
  }

}
