import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HistoricalLoginRoutingModule } from './historical-login-routing.module';
import { HistoricalLoginComponent } from './historical-login.component';



@NgModule({
  declarations: [HistoricalLoginComponent],
  imports: [
    CommonModule,
    HistoricalLoginRoutingModule,
  ]
})
export class HistoricalLoginModule { }
