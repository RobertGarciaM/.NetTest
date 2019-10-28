import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HistoricalLoginComponent } from './historical-login.component';

const routes: Routes = [
  {
    path: '',
    component: HistoricalLoginComponent
  }
];
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class HistoricalLoginRoutingModule { }
