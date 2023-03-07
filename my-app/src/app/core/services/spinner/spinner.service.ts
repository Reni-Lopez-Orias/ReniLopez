import { EventEmitter, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {

  spinner$ = new EventEmitter<boolean>();

  constructor() { }
}
