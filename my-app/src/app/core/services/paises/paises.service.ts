import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { RespuestaPaises } from '../../models/RespuesaPaises.interface';
import { environment } from "../../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class PaisesService {

  constructor(
    private _http: HttpClient
  ) { 
  }

  getPaises(){
    return this._http.get<RespuestaPaises[]>(`${environment.urlPaises}/all`)
    .pipe(
      map(this.filtrarPais)
    );
  }

  filtrarPais(response: RespuestaPaises[]){
    return  response.map(function(item){
      return { nombre: item.name.common, codigo: item.altSpellings[0] };
    })
  }

}

