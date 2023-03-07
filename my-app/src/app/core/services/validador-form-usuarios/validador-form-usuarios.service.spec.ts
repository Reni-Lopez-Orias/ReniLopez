import { TestBed } from '@angular/core/testing';

import { ValidadorFormUsuariosService } from './validador-form-usuarios.service';

describe('ValidadorFormUsuariosService', () => {
  let service: ValidadorFormUsuariosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ValidadorFormUsuariosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
