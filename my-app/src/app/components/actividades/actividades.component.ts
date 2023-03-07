import { Component, OnInit } from '@angular/core';
import { ActividadesInterface } from 'src/app/core/models/Actividaes.interface';
import { ActividadesService } from 'src/app/core/services/actividades/actividades.service';
import { SpinnerService } from 'src/app/core/services/spinner/spinner.service';

@Component({
  selector: 'app-actividades',
  templateUrl: './actividades.component.html',
  styleUrls: ['./actividades.component.css']
})
export class ActividadesComponent implements OnInit {

  spinner: boolean = true;
  actividades: ActividadesInterface[] = [];

  constructor(
    private _spinnerService: SpinnerService,
    private _servicioActividades: ActividadesService
  ) { }

  ngOnInit() {
    this.getActividades();
    this.getSpinner();
    this._spinnerService.spinner$.emit(this.spinner);
  }

  getSpinner() {
    this._spinnerService.spinner$.subscribe(data => {
      this.spinner = data;
    })
  }

  getActividades() {

    this._servicioActividades.obtenerActividades().subscribe(response => {
      this.actividades = response.respuesta;
    })


    // tiempo para ver loading
    setTimeout(() => {
      this._spinnerService.spinner$.emit(false);
    }, 1000);

  }

}
