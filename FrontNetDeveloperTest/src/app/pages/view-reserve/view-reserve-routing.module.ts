import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewReserveComponent } from './view-reserve.component';

const routes: Routes = [
  {
    path: '',
    component: ViewReserveComponent
  }
];
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ViewReserveRoutingModule { }
