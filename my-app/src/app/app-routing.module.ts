import { NgModule } from '@angular/core'; 
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [

 
  {
    path: 'usuarios',
    loadChildren: () => import('./components/usuarios/usuarios.module').then( m => m.UsuariosModule )
  },
  {
    path: 'actividades',
    loadChildren: () => import('./components/actividades/actividades.module').then( m => m.ActividadesModule )
  },
  {
    // el path vacio tiene que redirigir a algun path de estas rutas
    path: '**', redirectTo: 'usuarios'
  }
  

]


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports : [
    RouterModule
  ]
})
export class AppRoutingModule { }
