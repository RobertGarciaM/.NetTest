import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginModule } from './pages/login/login.module';
import { HomeModule } from './pages/home/home.module';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { InterceptoTokenService } from './interceptor/interceptor-token.service';
import { ViewReserveComponent } from './pages/view-reserve/view-reserve.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LoginModule,
    HomeModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptoTokenService,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
