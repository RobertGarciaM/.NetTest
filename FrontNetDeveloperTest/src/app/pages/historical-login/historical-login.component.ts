import { Component, OnInit } from '@angular/core';
import { HistoricalServices } from './service/historical.service';
import { DatosHistorical } from './interfaces/IHistorical';

@Component({
  selector: 'app-historical-login',
  templateUrl: './historical-login.component.html',
  styleUrls: ['./historical-login.component.css']
})
export class HistoricalLoginComponent implements OnInit {

  public listHistorical: DatosHistorical[];
  constructor(private historicalServices: HistoricalServices) { }

  ngOnInit() {
    if (sessionStorage.getItem('role') === '"Admin"') {
      this.historicalServices.GetHistorical().subscribe(response => {
        if ( response.status === 200) {
          this.listHistorical = response.data;
        }
      });
    }
  }

}
