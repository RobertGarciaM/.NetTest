import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewReserveComponent } from './view-reserve.component';
import { ViewReserveRoutingModule } from './view-reserve-routing.module';



@NgModule({
  declarations: [ViewReserveComponent],
  imports: [
    CommonModule,
    ViewReserveRoutingModule
  ]
})
export class ViewReserveModule { }
