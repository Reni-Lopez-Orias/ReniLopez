import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { RespuestUsuariosInterface } from '../../models/RespuestaUsuarios.interface';

@Injectable({
  providedIn: 'root'
})
export class ActividadesService {

  constructor(
    private _http: HttpClient
  ) { }

  obtenerActividades(){
    return this._http.get<RespuestUsuariosInterface>(`${environment.urlApi}/Actividades/Obtener`);
  }

}
