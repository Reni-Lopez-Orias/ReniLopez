import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PaisModel } from 'src/app/core/models/Pais.model';
import { RespuestUsuariosInterface } from 'src/app/core/models/RespuestaUsuarios.interface';
import { PaisesService } from 'src/app/core/services/paises/paises.service';
import { SpinnerService } from 'src/app/core/services/spinner/spinner.service';
import { UsuariosService } from 'src/app/core/services/usuarios/usuarios.service';
import { ValidadorFormUsuariosService } from 'src/app/core/services/validador-form-usuarios/validador-form-usuarios.service';
import { Acciones, CodigosRespuesta } from "../../core/enums/codigo-respuesta";
import Swal from 'sweetalert2'
import { UsuarioInterface } from 'src/app/core/models/Usuario.interface';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  spinner: boolean = true;
  userForm: FormGroup;
  paises: Array<PaisModel> = new Array<PaisModel>();
  fecha: string = "";
  usuarios: Array<UsuarioInterface> = new Array<UsuarioInterface>();
  paisSeleccionado: PaisModel[] = [];

  public constructor(
    private _paisesService: PaisesService,
    private _fb: FormBuilder,
    private _validadorFormUsuariosService: ValidadorFormUsuariosService,
    public _spinnerService: SpinnerService,
    private _usuarioService: UsuariosService
  ) {

    this.userForm = this._fb.group({
      id: [null],
      nombre: ['reni', [Validators.required, this._validadorFormUsuariosService.requerido('Nombre'), this._validadorFormUsuariosService.minimo(3, 'Nombre')]],
      apellido: ['reni', [Validators.required, this._validadorFormUsuariosService.requerido('Apellido'), this._validadorFormUsuariosService.minimo(3, 'Apellido')]],
      correoElectronico: ['reni@reni.com', [Validators.required, this._validadorFormUsuariosService.requerido('correoElectronico Electrónico'), this._validadorFormUsuariosService.email]],
      fechaNacimiento: ['', [Validators.required, this._validadorFormUsuariosService.requerido('Fecha Nacimiento')]],
      telefono: ['', [Validators.maxLength(8)]],
      paisResidencia: ['CRC', [Validators.required]],
      contacto: [false, [Validators.required]],
    });

  }

  ngOnInit() {
    this.obtenerUsuarios();
    this.formatoFechaForm();
    this.getSpinner();
    this.getPaises();
    this._spinnerService.spinner$.emit(this.spinner);
  }

  obtenerUsuarios() {
    this._usuarioService.obtenerUsuarios().subscribe(response => {
      this.validateResponse(response, Acciones.Ver);
    })
  }

  submitForm() { 
    
    if (this.userForm.valid) {
      (this.userForm.value.id != null) ? this.editarUsuario() : this.agregarUsuario();
    }
  }

  agregarUsuario() {
    let usuario = this.userForm.value;

    this._usuarioService.agregarUsuario(usuario).subscribe((response: any) => {
      this.validateResponse(response, Acciones.Agregar);
    })

  }

  editarUsuario() {
    let usuario = this.userForm.value;
    
    this._usuarioService.editarUsuario(usuario).subscribe((response: any) => {
      this.validateResponse(response, Acciones.Editar);
    })
  }

  seleccionarUsuario(usuario: UsuarioInterface) {

    let paisesTemp = this.paises.filter(x => x.codigo == usuario.paisResidencia);

    this.paisSeleccionado = paisesTemp;
    this.userForm.get('id')?.setValue(usuario.id);
    this.userForm.get('nombre')?.setValue(usuario.nombre);
    this.userForm.get('apellido')?.setValue(usuario.apellido);
    this.userForm.get('correoElectronico')?.setValue(usuario.correoElectronico);
    this.userForm.get('fechaNacimiento')?.setValue(new Date(usuario.fechaNacimiento).toISOString().split('T')[0]);
    this.userForm.get('telefono')?.setValue(usuario.telefono);
    this.userForm.get('paisResidencia')?.setValue(usuario.paisResidencia);
    this.userForm.get('contacto')?.setValue(usuario.contacto);
  
  }

  eliminarUsuario(usuario: UsuarioInterface) {
    Swal.fire({
      title: 'Confirmar eliminación?',
      showCancelButton: true,
      confirmButtonText: 'Eliminar',
    }).then((result) => {
      /* Read more about isConfirmed, isDenied below */
      if (result.isConfirmed) {
        this._usuarioService.eliminarUsuario(usuario.id).subscribe(response => {
          this.validateResponse(response, Acciones.Eliminar);
        })
      }
    })


  }

  validateResponse(response: RespuestUsuariosInterface, action: number) {

    var agregar = Acciones.Agregar == action && "Agregado";
    var editar = Acciones.Editar == action && "Editado";
    var eliminar = Acciones.Eliminar == action && "Eliminado";

    if (response.codigoRespuesta == CodigosRespuesta.Exito) {

      if (action == Acciones.Ver) {
     
        this.usuarios = response.respuesta;
      }
      if (action == Acciones.Eliminar) {
        this.usuarios = response.respuesta;
      }

      if (action == Acciones.Agregar && agregar) {
        this.customResetForm();
        Swal.fire(
          `${agregar} Correctamente!`,
          `${response.mensajeUsuario}`,
          'success'
        )
      }
      if (action == Acciones.Editar && editar) {
        this.customResetForm();
        Swal.fire(
          `${editar} Correctamente!`,
          `${response.mensajeUsuario}`,
          'success'
        )
      }
      if (action == Acciones.Eliminar && eliminar) {
        Swal.fire(`${eliminar} Correctamente!`, `${response.mensajeUsuario}`, 'success');

      }
 
    } else {
      Swal.fire(
        `Error!`,
        `${response.mensajeUsuario}`,
        'success'
      )
    }

  }

  formatoFechaForm() {
    var fechaTemp = new Date().toISOString();
    this.fecha = fechaTemp.toString().slice(0, -14);
  }


  getSpinner() {
    this._spinnerService.spinner$.subscribe(data => {
      this.spinner = data;
    })
  }

  getPaises() {

    this._paisesService.getPaises().subscribe((data: PaisModel[]) => {
      this.paises = data;
      this.paises.sort((x, y) => x.nombre.localeCompare(y.nombre));

      setTimeout(() => {
        this._spinnerService.spinner$.emit(false);
        this.spinner = false;
      }, 1000);
    })
  }

  customResetForm() {
    this.userForm.reset({
      id: null,
      nombre: '',
      apellido: '',
      correoElectronico: '',
      fechaNacimiento: '',
      telefono: '',
      paisResidencia: '',
      contacto: false,
    });
  }

  validarTelefono(event: any) {
    let patt = /^([0-9])$/;
    return patt.test(event.key);
  }

}
