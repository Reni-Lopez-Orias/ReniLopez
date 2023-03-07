import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReactiveFormsModule } from '@angular/forms';

//componetes
import { UsuariosRoutingModule } from './usuarios-routing.module';
import { UsuariosComponent } from './usuarios.component';
import { ActividadesModule } from '../actividades/actividades.module';
import { MensajeErrorComponent } from '../shared/mensaje-error/mensaje-error.component';

import { DataTablesModule } from "angular-datatables";

@NgModule({
  declarations: [
    UsuariosComponent,
    MensajeErrorComponent
  ],
  imports: [
    CommonModule,
    UsuariosRoutingModule,
    ActividadesModule,
    ReactiveFormsModule,
    DataTablesModule
  ]
})
export class UsuariosModule { }
