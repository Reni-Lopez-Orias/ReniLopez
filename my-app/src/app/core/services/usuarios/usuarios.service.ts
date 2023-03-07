import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { RespuestUsuariosInterface } from '../../models/RespuestaUsuarios.interface';
import { AgregarUsuarioInterface } from '../../models/Agregar-Usuario.interface';
import { EditarUsuarioInterface } from '../../models/Editar-Usuario.interface';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  constructor(
    private _http: HttpClient
  ) { }

  obtenerUsuarios(){
    return this._http.get<RespuestUsuariosInterface>(`${environment.urlApi}/Usuarios/ObtenerUsuarios`);
  }

  obtenerUsuario(id: number){
    return this._http.get<RespuestUsuariosInterface>(`${environment.urlApi}/Usuarios/ObtenerUsuario/${id}`);
  }

  agregarUsuario(usuario: AgregarUsuarioInterface){
    return this._http.post<AgregarUsuarioInterface>(`${environment.urlApi}/Usuarios/Agregar`, usuario); 
  }

  editarUsuario(usuario: EditarUsuarioInterface){
    return this._http.put<EditarUsuarioInterface>(`${environment.urlApi}/Usuarios/Editar/${usuario.id}`, usuario);
  }
  
  eliminarUsuario(id: number){
    return this._http.delete<RespuestUsuariosInterface>(`${environment.urlApi}/Usuarios/Eliminar/${id}`);
  }

}
