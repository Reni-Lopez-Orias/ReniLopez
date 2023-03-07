import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsuariosComponent } from './usuarios.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'usuarios', component: UsuariosComponent
      },
      {
        path: '**', redirectTo: 'usuarios'
      }
    ]

  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild( routes )
  ]
})
export class UsuariosRoutingModule { }
