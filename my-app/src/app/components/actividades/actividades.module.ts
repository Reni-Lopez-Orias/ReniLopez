import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActividadesRoutingModule } from './actividades-routing.module';
import { ActividadesComponent } from './actividades.component';



@NgModule({
  declarations: [
    ActividadesComponent
  ],
  imports: [
    CommonModule,
    ActividadesRoutingModule
    
  ],
  exports: [
    ActividadesComponent
  ],
})
export class ActividadesModule { }
