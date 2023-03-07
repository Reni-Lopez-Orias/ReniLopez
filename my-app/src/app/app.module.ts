import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { ActividadesModule } from './components/actividades/actividades.module';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { UsuariosModule } from './components/usuarios/usuarios.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { SpinnerComponent } from './components/shared/spinner/spinner.component';
import { InterceptorService } from './core/interceptor/interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SpinnerComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent],
  
})
export class AppModule { }
