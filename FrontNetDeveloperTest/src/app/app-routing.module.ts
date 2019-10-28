import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'historical', loadChildren: './pages/historical-login/historical-login.module#HistoricalLoginModule' },
  { path: 'users', loadChildren: './pages/users/users.module#UsersModule' },
  { path: 'products', loadChildren: './pages/products/products.module#ProductsModule' },
  { path: 'reserveview', loadChildren: './pages/view-reserve/view-reserve.module#ViewReserveModule' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
