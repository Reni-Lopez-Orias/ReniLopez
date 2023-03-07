import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ActividadesComponent } from '../actividades/actividades.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'actividades', component: ActividadesComponent
      },
      {
        path: '**', redirectTo: 'actividades'
      }
    ]

  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ]
})
export class ActividadesRoutingModule { }
