import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidadorFormUsuariosService {

  // en este servicio se pueden manejar validarciones personalizadas
  constructor() { }

  requerido(name: string) {
    return (control: FormControl) => {
      const value = control.value?.trim();
      if (control.dirty) {
        if (!value || value == '') {
          return {
            requiredInput: `${name} requerido`
          };
        }
      }
      return null;
    };
  }

  email(control: FormControl) { 
    const value = control.value;
    let regex: RegExp = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i;
    if (control.dirty) { 
      if (!regex.test(value)) { 
        return {
          email: `Correo no válido`
        };
      }
    }
    return null; 
  }

  minimo(length: number, label: string) {
    return (control: FormControl) => {
      const value = control.value;
      if (control.dirty) {
        if (value.length < length) {
          return {
            minLength: `${label} debe tener ${length} carácteres`
          };
        }
      }
      return null;
    };
  }


}
